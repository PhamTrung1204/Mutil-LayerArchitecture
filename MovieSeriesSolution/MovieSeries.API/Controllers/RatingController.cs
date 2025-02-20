using Microsoft.AspNetCore.Mvc;
using MovieSeries.CoreLayer.Entities;
using MovieSeries.ServiceLayer.Services;

namespace MovieSeries.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRatings()
        {
            var ratings = await _ratingService.GetAllRatingsAsync();
            return Ok(ratings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRating(int id)
        {
            var rating = await _ratingService.GetRatingByIdAsync(id);
            if (rating == null)
                return NotFound();
            return Ok(rating);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRating([FromBody] Ratings rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _ratingService.AddRatingAsync(rating);
            return CreatedAtAction(nameof(GetRating), new { id = rating.rating_id }, rating);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRating(int id, [FromBody] Ratings rating)
        {
            if (id != rating.rating_id)
                return BadRequest("ID không khớp.");

            await _ratingService.UpdateRatingAsync(rating);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            await _ratingService.DeleteRatingAsync(id);
            return NoContent();
        }
    }
}
