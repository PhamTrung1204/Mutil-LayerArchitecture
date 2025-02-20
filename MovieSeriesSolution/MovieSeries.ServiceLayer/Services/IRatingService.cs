using MovieSeries.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeries.ServiceLayer.Services
{
    public interface IRatingService
    {
        Task<IEnumerable<Ratings>> GetAllRatingsAsync();
        Task<Ratings> GetRatingByIdAsync(int id);
        Task AddRatingAsync(Ratings rating);
        Task UpdateRatingAsync(Ratings rating);
        Task DeleteRatingAsync(int id);
       
    }
}
