using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeries.CoreLayer.Entities
{
    public class Review
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UserId là bắt buộc.")]
        public int UserId { get; set; }

        // Navigation property: liên kết đến User
        public User User { get; set; }

        [Required(ErrorMessage = "MovieSeriesId là bắt buộc.")]
        public int MovieSeriesId { get; set; }

        // Navigation property: liên kết đến Movie (hoặc Film)
        public Movie Movie { get; set; }

        [Required(ErrorMessage = "ReviewText là bắt buộc.")]
        public string ReviewText { get; set; }

        public DateTime ReviewDate { get; set; } = DateTime.Now;
    }
}
