using System;
using System.ComponentModel.DataAnnotations;

namespace MovieSeries.CoreLayer.Entities
{
    public class Ratings
    {
        public int rating_id { get; set; }

        [Required(ErrorMessage = "UserId là bắt buộc.")]
        public int user_id { get; set; }

        // Quan hệ với User
        public User User { get; set; }

        [Required(ErrorMessage = "MovieSeriesId là bắt buộc.")]
        public int movie_series_id { get; set; }

        [Required(ErrorMessage = "Score là bắt buộc.")]
        [Range(0, 10, ErrorMessage = "Score phải nằm trong khoảng 0 đến 10.")]
        public decimal rating { get; set; }
    }
}