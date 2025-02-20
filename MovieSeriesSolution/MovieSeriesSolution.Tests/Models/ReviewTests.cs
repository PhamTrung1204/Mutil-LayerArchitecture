using MovieSeries.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeriesSolution.Tests.Models
{
    public class ReviewTests
    {
        [Theory]
        [InlineData(1, 1, "Nội dung review", 0)]    // Hợp lệ => 0 lỗi
        [InlineData(0, 1, "Nội dung review", 1)]    // user_id = 0 => 1 lỗi ([Required])
        [InlineData(1, 0, "Nội dung review", 1)]    // movie_series_id = 0 => 1 lỗi
        [InlineData(1, 1, "", 1)]                   // review_text rỗng => 1 lỗi
        [InlineData(0, 0, "", 3)]                   // 3 trường sai => 3 lỗi
        public void Review_Validation_ShouldReturnExpectedErrorCount(
            int userId,
            int movieSeriesId,
            string reviewText,
            int expectedErrorCount)
        {
            // Arrange
            var review = new Review
            {
                review_id = 0,
                user_id = userId,
                movie_series_id = movieSeriesId,
                review_text = reviewText,
                // review_date = DateTime.Now (mặc định)
            };

            // Act
            var results = ValidateModel(review);

            // Assert
            Assert.Equal(expectedErrorCount, results.Count);
        }

        [Fact]
        public void ReviewDate_ShouldBeNowByDefault()
        {
            // Arrange
            var review = new Review
            {
                user_id = 1,
                movie_series_id = 2,
                review_text = "Sample text"
            };

            // Act
            var results = ValidateModel(review);

            // Assert
            Assert.Empty(results); // Không có lỗi validation
            Assert.True(review.review_date <= DateTime.Now);
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
