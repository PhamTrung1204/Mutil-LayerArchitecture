using System;
using System.ComponentModel.DataAnnotations;

namespace MovieSeries.CoreLayer.Entities
{
    /// <summary>
    /// Đại diện cho người dùng (Users) trong ứng dụng.
    /// Tương ứng với bảng Users trong cơ sở dữ liệu.
    /// </summary>
    public class User
    {
        // Primary key, ánh xạ với user_id
        [Key]
        public int user_id { get; set; } // 

        [Required(ErrorMessage = "Username là bắt buộc.")]
        public string username { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string email { get; set; }

        // Quan hệ 1-nhiều với Review và Rating
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Ratings> Ratings { get; set; }
    }
}
