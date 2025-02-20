using MovieSeries.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeries.DataAccessLayer.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MoviesSeries>> GetAllMoviesAsync();
        Task AddMovieAsync(MoviesSeries movie);
        Task<IEnumerable<MoviesSeries>> GetTopRatedMoviesWithSpAsync(int topCount);
    }
}
