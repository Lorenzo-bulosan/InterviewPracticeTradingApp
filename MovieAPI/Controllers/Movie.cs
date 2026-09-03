using Microsoft.AspNetCore.Mvc;
using MovieAPI.Solution;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Movie : ControllerBase
    {
        private readonly ILogger<Movie> _logger;
        private readonly MovieCatalog _movieCatalog;

        public Movie(ILogger<Movie> logger, MovieCatalog movieCatalog)
        {
            _logger = logger;
            _movieCatalog = movieCatalog;
        }

        [HttpGet("GetMovies")]
        public ActionResult<List<Movie>> Get(string genre, int startYear, int endYear)
        {
            try
            {
                return Ok(_movieCatalog.Filter(genre, startYear, endYear));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, genre, startYear, endYear); 
                return BadRequest();
            }
        }
    }
}
