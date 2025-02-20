using System;

namespace MovieSeries.CoreLayer.Entities
{
    /// <summary>
    /// Đại diện cho người dùng (Users) trong ứng dụng.
    /// Tương ứng với bảng Users trong cơ sở dữ liệu.
    /// </summary>
    public class User
    {
        // Primary key, ánh xạ với user_id
        public int Id { get; set; }

        // Tên người dùng, không được null
        public string Username { get; set; }

        // Email, phải là duy nhất
        public string Email { get; set; }

        // Ngày giờ đăng ký (được thiết lập mặc định bằng GETDATE() trong SQL)
        public DateTime CreatedAt { get; set; }
    }
}
