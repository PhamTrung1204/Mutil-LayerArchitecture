using System.Collections.Generic;

namespace MovieSeries.CoreLayer.Entities
{
    /// <summary>
    /// Đại diện cho tag (Tags) dùng để phân loại nội dung phim/series.
    /// Tương ứng với bảng Tags trong cơ sở dữ liệu.
    /// </summary>
    public class Tag
    {
        // Primary key, ánh xạ với tag_id
        public int Id { get; set; }

        // Tên tag, không được null và phải duy nhất
        public string TagName { get; set; }

        // Navigation property cho mối quan hệ nhiều-nhiều với Movie (qua bảng MovieSeriesTags)
        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; }
    }
}
