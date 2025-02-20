using MovieSeries.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeriesSolution.Tests.Models
{
    public class MovieSeriesTagTests
    {
        [Theory]
        [InlineData(1, 1, 0)] // Cả movie_series_id=1, tag_id=1 => 0 lỗi
        [InlineData(0, 1, 1)] // movie_series_id=0 => 1 lỗi
        [InlineData(1, 0, 1)] // tag_id=0 => 1 lỗi
        [InlineData(0, 0, 2)] // Cả 2 đều 0 => 2 lỗi
        public void MovieSeriesTag_Validation_ShouldReturnExpectedErrorCount(
            int movieSeriesId,
            int tagId,
            int expectedErrorCount)
        {
            // Arrange
            var mst = new MovieSeriesTag
            {
                movie_series_id = movieSeriesId,
                tag_id = tagId,
                Movie = null, // Navigation property, ko check [Required]
                Tag = null
            };

            // Act
            var validationResults = ValidateModel(mst);

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
