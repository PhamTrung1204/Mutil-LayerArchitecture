namespace MovieSeries.CoreLayer.Entities
{
    /// <summary>
    /// Đại diện cho bảng trung gian MovieSeriesTags giữa Movies và Tags.
    /// Xác định mối quan hệ nhiều-nhiều giữa phim/series và các tag.
    /// </summary>
    public class MovieSeriesTag
    {
        // Khóa ngoại ánh xạ với MoviesSeries (thường là entity Movie)
        public int MovieSeriesId { get; set; }

        // Khóa ngoại ánh xạ với Tags (entity Tag)
        public int TagId { get; set; }

        // Navigation property để truy xuất thông tin phim (MoviesSeries)
        public Movie Movie { get; set; }

        // Navigation property để truy xuất thông tin tag
        public Tag Tag { get; set; }
    }
}