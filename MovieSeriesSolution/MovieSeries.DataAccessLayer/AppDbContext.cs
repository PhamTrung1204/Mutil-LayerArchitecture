using Microsoft.EntityFrameworkCore;
using MovieSeries.CoreLayer.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MovieSeries.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        // Các DbSet ánh xạ đến các bảng trong cơ sở dữ liệu
        public DbSet<MoviesSeries> MoviesSeries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MovieSeriesTag> MovieSeriesTags { get; set; }
        public DbSet<Ratings> Ratings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesSeries>()
        .HasKey(m => m.movie_series_id);
            // Cấu hình cho bảng trung gian (nhiều - nhiều) giữa Movies và Tags
            modelBuilder.Entity<MovieSeriesTag>()
                .HasKey(mst => new { mst.movie_series_id, mst.tag_id });

            modelBuilder.Entity<MovieSeriesTag>()
                .HasOne(mst => mst.MovieSeries)
                .WithMany(m => m.MovieSeriesTags)
                .HasForeignKey(mst => mst.movie_series_id);

            modelBuilder.Entity<MovieSeriesTag>()
                .HasOne(mst => mst.Tag)
                .WithMany(t => t.MovieSeriesTags)
                .HasForeignKey(mst => mst.tag_id);
        }
    }
}