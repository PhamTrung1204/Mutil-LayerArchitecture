using System;

namespace MovieSeries.CoreLayer.Entities
{
    /// <summary>
    /// Đại diện cho bảng Ratings, lưu trữ các đánh giá của người dùng cho phim/series.
    /// Tương ứng với bảng Ratings trong cơ sở dữ liệu.
    /// </summary>
    public class Ratings
    {
        // Primary key, ánh xạ với rating_id
        public int Id { get; set; }

        // Khóa ngoại ánh xạ với người dùng (Users)
        public int UserId { get; set; }

        // Khóa ngoại ánh xạ với phim/series (MoviesSeries)
        // Trong entity Movie, chúng ta sử dụng thuộc tính Id để ánh xạ
        public int MovieId { get; set; }

        // Giá trị đánh giá, kiểu số thập phân từ 0 đến 10
        public decimal Value { get; set; }

        // Navigation property: liên kết với người dùng
        public User User { get; set; }

        // Navigation property: liên kết với phim (Movie)
        public Movie Movie { get; set; }
    }
}