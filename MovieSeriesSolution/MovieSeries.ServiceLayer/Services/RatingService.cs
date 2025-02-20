using MovieSeries.CoreLayer.Entities;
using MovieSeries.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeries.ServiceLayer.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<IEnumerable<Ratings>> GetAllRatingsAsync()
        {
            return await _ratingRepository.GetAllAsync();
        }

        public async Task<Ratings> GetRatingByIdAsync(int id)
        {
            return await _ratingRepository.GetByIdAsync(id);
        }

        public async Task AddRatingAsync(Ratings rating)
        {
            // Có thể thêm logic nghiệp vụ (ví dụ: kiểm tra xem user đã đánh giá phim chưa)
            await _ratingRepository.AddAsync(rating);
        }

        public async Task UpdateRatingAsync(Ratings rating)
        {
            await _ratingRepository.UpdateAsync(rating);
        }

        public async Task DeleteRatingAsync(int id)
        {
            await _ratingRepository.DeleteAsync(id);
        }
    }
}
