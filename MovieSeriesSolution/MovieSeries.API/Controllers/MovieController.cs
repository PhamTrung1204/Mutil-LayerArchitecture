using Microsoft.AspNetCore.Mvc;
using MovieSeries.CoreLayer.Entities;
using MovieSeries.ServiceLayer.Services;
using System.Threading.Tasks;

namespace MovieSeries.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/movie/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            // Giả sử có phương thức GetMovieByIdAsync (có thể bổ sung trong Service Layer nếu cần)
            var movie = await _movieService.GetAllMoviesAsync(); // Hoặc gọi riêng GetMovieByIdAsync(id)
            if (movie == null)
                return NotFound();
            return Ok(movie);
        }

        // GET: api/movie/top-rated/{count}
        [HttpGet("top-rated/{count}")]
        public async Task<IActionResult> GetTopRatedMovies(int count)
        {
            var movies = await _movieService.GetTopRatedMoviesWithSpAsync(count);
            return Ok(movies);
        }

        // POST: api/movie
        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] MoviesSeries movie)
        {
            await _movieService.AddMovieAsync(movie);
            // Có thể trả về CreatedAtAction với đường dẫn đến GetMovie nếu muốn
            return CreatedAtAction(nameof(GetMovie), new { id = movie.movie_series_id }, movie);
        }
    }
}
