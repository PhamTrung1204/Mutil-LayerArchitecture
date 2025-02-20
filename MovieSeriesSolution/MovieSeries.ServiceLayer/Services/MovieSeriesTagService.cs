using MovieSeries.CoreLayer.Entities;
using MovieSeries.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeries.ServiceLayer.Services
{
    public class MovieSeriesTagService : IMovieSeriesTagService
    {
        private readonly IMovieSeriesTagRepository _repository;

        public MovieSeriesTagService(IMovieSeriesTagRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MovieSeriesTag>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<MovieSeriesTag> GetByIdsAsync(int movieSeriesId, int tagId)
        {
            return await _repository.GetByIdsAsync(movieSeriesId, tagId);
        }

        public async Task AddAsync(MovieSeriesTag movieSeriesTag)
        {
            // Có thể thêm logic nghiệp vụ kiểm tra trùng lặp nếu cần
            await _repository.AddAsync(movieSeriesTag);
        }

        public async Task DeleteAsync(int movieSeriesId, int tagId)
        {
            await _repository.DeleteAsync(movieSeriesId, tagId);
        }
    }
}
