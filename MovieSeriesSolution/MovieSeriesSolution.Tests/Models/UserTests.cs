using MovieSeries.CoreLayer.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using System.Linq;

namespace MovieSeriesSolution.Tests.Models
{
    public class UserTests
    {
        [Theory]
        [InlineData("", "user@example.com", 1)]         // username bị rỗng => 1 lỗi
        [InlineData("Alice", "", 1)]                    // email bị rỗng => 1 lỗi
        [InlineData("Bob", "invalid-email", 1)]         // email sai format => 1 lỗi
        [InlineData("Charlie", "charlie@abc.com", 0)]   // hợp lệ => 0 lỗi
        public void User_Validation_ShouldReturnExpectedErrorCount(
            string username,
            string email,
            int expectedErrorCount)
        {
            // Arrange
            var user = new User
            {
                user_id = 0, // Khoá chính (ID) không cần kiểm thử validation
                username = username,
                email = email
            };

            // Act
            var validationResults = ValidateModel(user);

            // Assert
            Assert.Equal(expectedErrorCount, validationResults.Count);
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
