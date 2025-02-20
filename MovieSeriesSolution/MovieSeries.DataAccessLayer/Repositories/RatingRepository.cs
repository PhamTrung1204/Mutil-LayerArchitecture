using Microsoft.EntityFrameworkCore;
using MovieSeries.CoreLayer.Entities;
using MovieSeries.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeries.DataAccessLayer.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AppDbContext _context;

        public RatingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ratings>> GetAllAsync()
        {
            return await _context.Ratings
                .Include(r => r.user_id)
                .ToListAsync();
        }

        public async Task<Ratings> GetByIdAsync(int id)
        {
            return await _context.Ratings
                .Include(r => r.user_id)
                .FirstOrDefaultAsync(r => r.rating_id == id);
        }

        public async Task AddAsync(Ratings rating)
        {
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ratings rating)
        {
            _context.Ratings.Update(rating);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var rating = await _context.Ratings.FindAsync(id);
            if (rating != null)
            {
                _context.Ratings.Remove(rating);
                await _context.SaveChangesAsync();
            }
        }
        
    }
}
