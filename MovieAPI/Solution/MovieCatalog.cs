using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MovieAPI.Solution
{
    // Normally separated into its own folder
    public class Movie
    {
        public int MovieId { get; }
        public string Title { get; }
        public int Year { get; }
        public IReadOnlyList<string> Genres { get; }

        public Movie(int movieId, string title, int year, IEnumerable<string> genres)
        {
            MovieId = movieId;
            Title = title;
            Year = year;
            Genres = genres.ToList().AsReadOnly();
        }
    }

    public class MovieCatalog
    {
        private readonly List<Movie> _movies;
        private Dictionary<string, List<Movie>> _moviesByGenre = new Dictionary<string, List<Movie>>();

        public MovieCatalog()
        {
            string csvPath = Path.Combine("Data", "movies.csv");
            _movies = LoadMovies(csvPath).ToList();

            // no database so we will use a dictionary in memory
            // plan will be to group by genre instead of year
            // then sort them in year order ascending so we can perform some search like binary search
            foreach (var movie in _movies)
            {
                foreach (var genre in movie.Genres)
                {
                    if (!_moviesByGenre.ContainsKey(genre))
                    {
                        _moviesByGenre.Add(genre, new List<Movie>());
                    }
                    _moviesByGenre[genre].Add(movie);
                }
            }

            // Now we have a group of movies by genre
            // Sort the movies inside the genres by year
            foreach(var keyValuePair in _moviesByGenre)
            {
                _moviesByGenre[keyValuePair.Key] = _moviesByGenre[keyValuePair.Key].OrderBy(m => m.Year).ToList();
            }
        }

        private static IEnumerable<Movie> LoadMovies(string csvPath)
        {
            using var reader = new StreamReader(csvPath);
            string? line;
            bool headerSkipped = false;

            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                // Skip header row if present
                if (!headerSkipped)
                {
                    headerSkipped = true;
                    if (line.StartsWith("movieId", StringComparison.OrdinalIgnoreCase))
                        continue;
                }

                var parts = line.Split(',');
                if (parts.Length < 4) continue;

                if (!int.TryParse(parts[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out int id))
                    continue;

                string title = parts[1].Trim();

                if (!int.TryParse(parts[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out int year))
                    continue;

                var genres = parts[3]
                    .Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Where(g => g.Length > 0)
                    .ToArray();

                // Problem guarantees at least one genre
                yield return new Movie(id, title, year, genres);
            }
        }

        /// <summary>
        /// Brute-force filter: scan every movie.
        /// </summary>
        public List<Movie> Filter(string genre, int startYear, int endYear)
        {
            var result = new List<Movie>();

            // validate string null or whitespace and start year not after endyear
            if (string.IsNullOrWhiteSpace(genre) || startYear > endYear)
                return result;

            // check if genre in dictionary for early return
            if (!_moviesByGenre.ContainsKey(genre))
            {
                return result;
            }

            var moviesFilteredByGenre = _moviesByGenre[genre];

            // LINQ solution
            var result1 = moviesFilteredByGenre.Where(m => startYear <= m.Year && m.Year <= endYear).ToList();
            //return result;

            // Binary search solution for start year
            int left = 0;
            int right = moviesFilteredByGenre.Count()-1;
            int mid = 0;
            while(left <= right)
            {
                mid = (left + right) / 2;

                // check movie in the middle
                if (moviesFilteredByGenre[mid].Year == startYear)
                {
                    // keep going left to find first occurence
                    while (moviesFilteredByGenre[mid].Year == startYear)
                    {
                        mid -= 1;
                    }

                    // we found the first occurrence of startYear
                    break;
                }
                else if (moviesFilteredByGenre[mid].Year < mid)
                {
                    left = mid + 1;
                }
                else if(moviesFilteredByGenre[mid].Year > mid)
                {
                    right = mid - 1;
                }
            }

            var firstMovieAtStartYear = mid;

            // Binary search solution for end year
            left = 0;
            right = moviesFilteredByGenre.Count() - 1;
            mid = 0;
            while (left <= right)
            {
                mid = (left + right) / 2;

                // check movie in the middle
                if (moviesFilteredByGenre[mid].Year == endYear)
                {
                    // keep going RIGHT to find LAST occurence
                    while (moviesFilteredByGenre[mid].Year == endYear)
                    {
                        mid += 1;
                    }

                    // we found the LAST occurrence of endYear
                    break;
                }
                else if (moviesFilteredByGenre[mid].Year < mid)
                {
                    left = mid + 1;
                }
                else if (moviesFilteredByGenre[mid].Year > mid)
                {
                    right = mid - 1;
                }
            }

            var lastMovieAtEndYear = mid;

            // return range
            result = moviesFilteredByGenre.GetRange(firstMovieAtStartYear, lastMovieAtEndYear-firstMovieAtStartYear);

            //foreach (var movie in _movies)
            //{
            //    // Check year range first (cheap)
            //    if (movie.Year < startYear || movie.Year > endYear)
            //        continue;

            //    // Check if the movie contains the requested genre
            //    if (movie.Genres.Contains(genre, StringComparer.OrdinalIgnoreCase))
            //    {
            //        result.Add(movie);
            //    }
            //}

            return result;
        }
    }
}
