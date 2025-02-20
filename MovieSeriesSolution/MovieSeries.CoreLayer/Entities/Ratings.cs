using System;
using System.ComponentModel.DataAnnotations;

namespace MovieSeries.CoreLayer.Entities
{
    public class Ratings
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UserId là bắt buộc.")]
        public int UserId { get; set; }

        // Quan hệ với User
        public User User { get; set; }

        [Required(ErrorMessage = "MovieSeriesId là bắt buộc.")]
        public int MovieSeriesId { get; set; }

        // Quan hệ với Movie (hoặc MovieSeries)
        public Movie Movie { get; set; }

        [Required(ErrorMessage = "Score là bắt buộc.")]
        [Range(0, 10, ErrorMessage = "Score phải nằm trong khoảng 0 đến 10.")]
        public decimal Score { get; set; }
    }
}