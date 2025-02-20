using MovieSeries.CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieSeries.ServiceLayer.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task AddMovieAsync(Movie movie);
        Task<IEnumerable<Movie>> GetTopRatedMoviesWithSpAsync(int topCount);
    }
}