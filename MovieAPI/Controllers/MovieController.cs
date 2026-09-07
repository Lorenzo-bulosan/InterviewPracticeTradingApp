using Microsoft.AspNetCore.Mvc;
using MovieAPI.Solution;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly MovieCatalog _movieCatalog;

        public MovieController(ILogger<MovieController> logger, MovieCatalog movieCatalog)
        {
            _logger = logger;
            _movieCatalog = movieCatalog;
        }

        [HttpGet]
        public ActionResult<List<Movie>> GetMovies(string genre, int startYear, int endYear)
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
