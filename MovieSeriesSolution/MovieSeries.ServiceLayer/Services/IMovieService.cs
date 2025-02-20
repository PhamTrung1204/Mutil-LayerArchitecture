using MovieSeries.CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieSeries.ServiceLayer.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MoviesSeries>> GetAllMoviesAsync();
        Task AddMovieAsync(MoviesSeries movie);
        Task<IEnumerable<MoviesSeries>> GetTopRatedMoviesWithSpAsync(int topCount);
    }
}