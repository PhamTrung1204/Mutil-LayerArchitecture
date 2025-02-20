using MovieSeries.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeries.DataAccessLayer.Repositories.Interfaces
{
    public interface IMovieSeriesTagRepository
    {
        Task<IEnumerable<MovieSeriesTag>> GetAllAsync();
        Task<MovieSeriesTag> GetByIdsAsync(int movieSeriesId, int tagId);
        Task AddAsync(MovieSeriesTag movieSeriesTag);
        Task DeleteAsync(int movieSeriesId, int tagId);
    }
}
