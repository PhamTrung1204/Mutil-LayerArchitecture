using Microsoft.EntityFrameworkCore;
using MovieSeries.CoreLayer.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MovieSeries.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        // Các DbSet ánh xạ đến các bảng trong cơ sở dữ liệu
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MovieSeriesTag> MovieSeriesTags { get; set; }
        public DbSet<Ratings> Ratings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình cho bảng trung gian (nhiều - nhiều) giữa Movies và Tags
            modelBuilder.Entity<MovieSeriesTag>()
                .HasKey(mst => new { mst.MovieSeriesId, mst.TagId });

            modelBuilder.Entity<MovieSeriesTag>()
                .HasOne(mst => mst.Movie)
                .WithMany(m => m.MovieSeriesTags)
                .HasForeignKey(mst => mst.MovieSeriesId);

            modelBuilder.Entity<MovieSeriesTag>()
                .HasOne(mst => mst.Tag)
                .WithMany(t => t.MovieSeriesTags)
                .HasForeignKey(mst => mst.TagId);
        }
    }
}