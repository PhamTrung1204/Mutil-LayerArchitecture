﻿using Microsoft.EntityFrameworkCore;
using MovieSeries.CoreLayer.Entities;
using MovieSeries.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeries.DataAccessLayer.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        // Phương thức lấy tất cả phim
        public async Task<IEnumerable<MoviesSeries>> GetAllMoviesAsync()
        {
            return await _context.MoviesSeries.ToListAsync();
        }

        // Phương thức thêm phim mới
        public async Task AddMovieAsync(MoviesSeries movie)
        {
            await _context.MoviesSeries.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        // Phương thức gọi Stored Procedure lấy top phim được đánh giá cao
        public async Task<IEnumerable<MoviesSeries>> GetTopRatedMoviesWithSpAsync(int topCount)
        {
            return await _context.MoviesSeries
                .FromSqlRaw("EXEC GetTopRatedMovies @top_count = {0}", topCount)
                .ToListAsync();
        }
    }
}
