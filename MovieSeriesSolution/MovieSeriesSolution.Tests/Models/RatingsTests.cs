using MovieSeries.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeriesSolution.Tests.Models
{
    public class RatingTests
    {
        // Ví dụ: Kiểm tra [Range(0, 10)] cho Value
        [Theory]
        [InlineData(5.0, 0)]   // 5.0 → Không lỗi
        [InlineData(-1, 1)]    // -1 → Lỗi
        [InlineData(11, 1)]    // 11 → Lỗi
        public void Rating_ValueValidation_ShouldReturnExpectedErrors(
            decimal ratingValue,
            int expectedErrorCount)
        {
            // Arrange
            var rating = new Ratings
            {
                Score = ratingValue,
                UserId = 1,   // Giả sử bắt buộc
                Id = 1   // Giả sử bắt buộc
            };

            // Act
            var results = ValidateModel(rating);

            // Assert
            Assert.Equal(expectedErrorCount, results.Count);
        }

        private List<ValidationResult> ValidateModel(object model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, context, results, true);
            return results;
        }
    }
}
