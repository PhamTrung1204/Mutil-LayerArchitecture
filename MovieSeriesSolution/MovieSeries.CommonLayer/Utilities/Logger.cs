using System;

namespace MovieSeries.CommonLayer.Utilities
{
    /// <summary>
    /// Lớp tiện ích log để ghi lại các thông tin, lỗi, hoặc các sự kiện quan trọng của ứng dụng.
    /// Ở đây sử dụng Console để demo, có thể mở rộng ghi log vào file, database hay hệ thống log chuyên dụng.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Log thông điệp thông thường.
        /// </summary>
        /// <param name="message">Thông điệp cần ghi log</param>
        public static void Log(string message)
        {
            // Ghi log với thời gian hiện tại
            Console.WriteLine($"[{DateTime.Now}] INFO: {message}");
        }

        /// <summary>
        /// Log lỗi kèm theo Exception.
        /// </summary>
        /// <param name="ex">Exception cần log</param>
        public static void LogError(Exception ex)
        {
            // Ghi log lỗi chi tiết: thông báo và stack trace
            Console.WriteLine($"[{DateTime.Now}] ERROR: {ex.Message}\n{ex.StackTrace}");
        }
    }
}