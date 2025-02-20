# 🎬 Ứng Dụng Đánh Giá Phim/Series

## 📌 Tổng Quan

Đây là một ứng dụng nhiều lớp được xây dựng bằng C# .NET Core để quản lý đánh giá phim/series. Dự án tuân theo kiến trúc sạch với các lớp riêng biệt cho truy cập dữ liệu, logic nghiệp vụ và xử lý API. Ứng dụng cho phép người dùng tạo tài khoản, gửi đánh giá, xếp hạng phim/series và phân loại nội dung bằng thẻ.

## 🚀 Tính Năng

- 🔑 Quản lý người dùng và xác thực
- 🎥 CRUD cho phim/series
- ✍️ Người dùng gửi đánh giá và xếp hạng
- 🏷️ Phân loại phim/series theo thẻ
- 📊 Stored Procedures để tối ưu hóa thao tác dữ liệu
- ✅ Kiểm thử đơn vị và tích hợp với xUnit
- 🛠️ Tiện ích logging và validation trong Common Layer
- 🌐 API phục vụ cho frontend

## 🛠️ Công Nghệ Sử Dụng

- **Backend**: ASP.NET Core Web API
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **Testing**: xUnit, Moq
- **Logging**: Custom Logger Utility

## 🏗️ Kiến Trúc Ứng Dụng

1. **Core Layer**: Định nghĩa các thực thể và mô hình chia sẻ
2. **Data Access Layer (DAL)**: Triển khai Repository Pattern để thao tác cơ sở dữ liệu
3. **Business Layer**: Chứa logic nghiệp vụ và các phương thức xử lý
4. **Service Layer**: Kết nối Controllers và Repository
5. **Common Layer**: Cung cấp các chức năng tiện ích (logging, validation, xử lý lỗi)
6. **API Layer (Controllers)**: Cung cấp các endpoint RESTful

## 📊 Cấu Trúc Cơ Sở Dữ Liệu

- **👤 Users**: Lưu thông tin người dùng
- **🎞️ MoviesSeries**: Chứa thông tin phim/series
- **✍️ Reviews**: Chứa đánh giá từ người dùng
- **⭐ Ratings**: Lưu trữ điểm xếp hạng của người dùng
- **🏷️ Tags**: Hỗ trợ phân loại nội dung
- **🔗 MovieSeriesTags**: Triển khai mối quan hệ nhiều-nhiều giữa phim và thẻ

## 🛠️ Cài Đặt

1. Clone repository:
   ```sh
   git clone [https://github.com/PhamTrung1204/Mutil-LayerArchitecture.git]
   cd Mutil-LayerArchitecture
   ```
2. Cấu hình cơ sở dữ liệu:
   - Chạy `FilmReviewDB.sql` trong SQL Server
3. Cấu hình `appsettings.json` với kết nối cơ sở dữ liệu
4. Chạy backend server:
   ```sh
   dotnet run --project MovieSeries.API
   ```

## ✅ Kiểm Thử

- Chạy tất cả Unit Test:
  ```sh
  dotnet test
  ```
- Chạy kiểm thử API với Postman

## 🌍 API Endpoints

- **GET** `/api/movies` - Lấy danh sách phim
- **GET** `/api/movies/{id}` - Lấy thông tin chi tiết của một bộ phim
- **POST** `/api/reviews` - Gửi đánh giá mới
- **GET** `/api/movies/top-rated` - Lấy danh sách phim được đánh giá cao nhất
- **GET** `/api/movies/by-tag/{tag}` - Lọc phim theo thẻ

## 🔮 Cải Tiến Trong Tương Lai

- 🔐 Triển khai xác thực bằng JWT
- 🎨 Phát triển frontend với React
- 🚀 Tối ưu hiệu suất với caching

## 👨‍💻 Đóng Góp

- **👨‍💻 Phạm Trung**: Cơ sở dữ liệu & Stored Procedures
- **👩‍💻 Nguyễn Hoàng Minh Tấn**: Triển khai Backend API
- **👩‍💻 Nguyễn Tuấn Dũng**: Kiểm thử đơn vị & tích hợp

## 📜 Giấy Phép

Dự án này được cấp phép theo MIT License.
## 📞 Liên hệ
- **👨‍💻 Phạm Trung**: trungpham.31221024740@st.ueh.edu.vn
- **👩‍💻 Nguyễn Hoàng Minh Tấn**: ngophucnguyen1976@gmail.com
- **👨‍🔬 Nguyễn Tuấn Dũng**: dnguyentuan03@gmail.com

