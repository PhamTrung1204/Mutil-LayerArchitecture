using Microsoft.AspNetCore.Mvc;
using MovieSeries.CoreLayer.Entities;
using MovieSeries.ServiceLayer.Services;

namespace MovieSeries.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieSeriesTagController : ControllerBase
    {
        private readonly IMovieSeriesTagService _service;

        public MovieSeriesTagController(IMovieSeriesTagService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<MovieSeriesTag> associations = await _service.GetAllAsync();
            return Ok(associations);
        }

        [HttpGet("{movieSeriesId}/{tagId}")]
        public async Task<IActionResult> Get(int movieSeriesId, int tagId)
        {
            MovieSeriesTag association = await _service.GetByIdsAsync(movieSeriesId, tagId);
            if (association == null)
                return NotFound();
            return Ok(association);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MovieSeriesTag movieSeriesTag)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddAsync(movieSeriesTag);
            return CreatedAtAction(nameof(Get), new { movieSeriesId = movieSeriesTag.MovieSeriesId, tagId = movieSeriesTag.TagId }, movieSeriesTag);
        }

        [HttpDelete("{movieSeriesId}/{tagId}")]
        public async Task<IActionResult> Delete(int movieSeriesId, int tagId)
        {
            await _service.DeleteAsync(movieSeriesId, tagId);
            return NoContent();
        }
    }
}
