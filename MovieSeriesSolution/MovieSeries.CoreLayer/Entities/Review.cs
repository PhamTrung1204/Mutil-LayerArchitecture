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
        [Key]
        public int review_id { get; set; }

        [Required(ErrorMessage = "UserId là bắt buộc.")]
        public int user_id { get; set; }

        [Required(ErrorMessage = "MovieSeriesId là bắt buộc.")]
        public int movie_series_id { get; set; }

        [Required(ErrorMessage = "ReviewText là bắt buộc.")]
        public string review_text { get; set; }

        public DateTime review_date { get; set; } = DateTime.Now;
    }
}
