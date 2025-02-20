using MovieSeries.CoreLayer.Entities;
using MovieSeries.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieSeries.ServiceLayer.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // Phương thức lấy tất cả phim
        public async Task<IEnumerable<MoviesSeries>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllMoviesAsync();
        }

        // Phương thức thêm phim mới (có thể tích hợp thêm logic kiểm tra, ví dụ kiểm tra trùng tiêu đề)
        public async Task AddMovieAsync(MoviesSeries movie)
        {
            // Ví dụ: kiểm tra nếu đã tồn tại phim có tiêu đề trùng lặp (logic bổ sung nếu cần)
            // Nếu hợp lệ, gọi repository để thêm phim
            await _movieRepository.AddMovieAsync(movie);
        }

        // Phương thức gọi stored procedure lấy top phim được đánh giá cao
        public async Task<IEnumerable<MoviesSeries>> GetTopRatedMoviesWithSpAsync(int topCount)
        {
            return await _movieRepository.GetTopRatedMoviesWithSpAsync(topCount);
        }
    }
}