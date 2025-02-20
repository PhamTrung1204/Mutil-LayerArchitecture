using System.ComponentModel.DataAnnotations;

namespace MovieSeries.CoreLayer.Entities
{
    public class MovieSeriesTag
    {
        [Required(ErrorMessage = "MovieSeriesId là bắt buộc.")]
        public int movie_series_id { get; set; }

        // Navigation property: Giả sử Movie là entity đại diện cho phim hoặc series
        public MoviesSeries MovieSeries { get; set; }

        [Required(ErrorMessage = "TagId là bắt buộc.")]
        public int tag_id { get; set; }

        // Navigation property cho Tag
        public Tag Tag { get; set; }
    }
}