using System.ComponentModel.DataAnnotations;

namespace MovieSeries.CoreLayer.Entities
{
    public class MovieSeriesTag
    {
        [Required(ErrorMessage = "MovieSeriesId là bắt buộc.")]
        public int MovieSeriesId { get; set; }

        // Navigation property: Giả sử Movie là entity đại diện cho phim hoặc series
        public Movie Movie { get; set; }

        [Required(ErrorMessage = "TagId là bắt buộc.")]
        public int TagId { get; set; }

        // Navigation property cho Tag
        public Tag Tag { get; set; }
    }
}