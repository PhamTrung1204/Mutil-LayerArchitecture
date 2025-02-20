using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeries.CommonLayer.Utilities
{
    public class ErrorHandler
    {
        public static string GetErrorMessage(System.Exception ex)
        {
            // Tùy chỉnh xử lý lỗi theo yêu cầu, ví dụ log lỗi, trả về thông báo chung
            return ex.Message;
        }
    }
}
