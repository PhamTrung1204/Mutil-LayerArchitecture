using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieSeries.CoreLayer.Entities
{
    public class Tag
    {
        public int tag_id { get; set; }

        [Required(ErrorMessage = "TagName là bắt buộc.")]
        public string tag_name { get; set; }

        // Quan hệ nhiều-nhiều với Movie qua bảng trung gian MovieSeriesTag
        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; }
    }
}
