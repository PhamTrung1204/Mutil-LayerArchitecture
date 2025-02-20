using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieSeries.CoreLayer.Entities
{
    public class Tag
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "TagName là bắt buộc.")]
        public string TagName { get; set; }

        // Quan hệ nhiều-nhiều với Movie qua bảng trung gian MovieSeriesTag
        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; }
    }
}
