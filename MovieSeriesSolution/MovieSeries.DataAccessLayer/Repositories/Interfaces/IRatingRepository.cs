using MovieSeries.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeries.DataAccessLayer.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        Task<IEnumerable<Ratings>> GetAllAsync();
        Task<Ratings> GetByIdAsync(int id);
     

        Task AddAsync(Ratings rating);
        Task UpdateAsync(Ratings rating);
        Task DeleteAsync(int id);
    }
}
