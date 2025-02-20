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
    public class MovieSeriesTagRepository : IMovieSeriesTagRepository
    {
        private readonly AppDbContext _context;

        public MovieSeriesTagRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieSeriesTag>> GetAllAsync()
        {
            return await _context.MovieSeriesTags
                .Include(mst => mst.Movie)
                .Include(mst => mst.Tag)
                .ToListAsync();
        }

        public async Task<MovieSeriesTag> GetByIdsAsync(int movieSeriesId, int tagId)
        {
            return await _context.MovieSeriesTags
                .Include(mst => mst.Movie)
                .Include(mst => mst.Tag)
                .FirstOrDefaultAsync(mst => mst.MovieSeriesId == movieSeriesId && mst.TagId == tagId);
        }

        public async Task AddAsync(MovieSeriesTag movieSeriesTag)
        {
            await _context.MovieSeriesTags.AddAsync(movieSeriesTag);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int movieSeriesId, int tagId)
        {
            var entity = await GetByIdsAsync(movieSeriesId, tagId);
            if (entity != null)
            {
                _context.MovieSeriesTags.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
