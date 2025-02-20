using MovieSeries.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeriesSolution.Tests.Models
{
    public class TagTests
    {
        [Theory]
        [InlineData("", 1)]       // tag_name rỗng => 1 lỗi (do [Required])
        [InlineData("Action", 0)] // hợp lệ => 0 lỗi
        public void Tag_Validation_ShouldReturnExpectedErrorCount(
            string tagName,
            int expectedErrorCount)
        {
            // Arrange
            var tag = new Tag
            {
                tag_id = 0,
                tag_name = tagName
                // Bỏ qua MovieSeriesTags trong validation, 
                // vì nó không có [Required].
            };

            // Act
            var validationResults = ValidateModel(tag);

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
