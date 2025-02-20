using Moq;
using MovieSeries.CoreLayer.Entities;
using MovieSeries.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeriesSolution.Tests.Repositories
{
    public class RatingRepositoryTests
    {
        private readonly Mock<IRatingRepository> _repositoryMock;

        public RatingRepositoryTests()
        {
            _repositoryMock = new Mock<IRatingRepository>();
        }

        [Fact]
        public async Task AddAsync_ShouldCallAddAsync_WhenRatingIsValid()
        {
            // Arrange
            var rating = new Ratings { UserId = 1, MovieSeriesId = 10, Score = 8 };
            _repositoryMock.Setup(r => r.AddAsync(rating))
                           .Returns(Task.CompletedTask);

            // Act
            await _repositoryMock.Object.AddAsync(rating);

            // Assert
            _repositoryMock.Verify(r => r.AddAsync(rating), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnRatingsList()
        {
            // Arrange
            var ratings = new List<Ratings>
            {
                new Ratings { Id = 1, UserId = 1, MovieSeriesId = 10, Score = 7 },
                new Ratings { Id = 2, UserId = 2, MovieSeriesId = 10, Score = 9 }
            };

            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(ratings);

            // Act
            var result = await _repositoryMock.Object.GetAllAsync();

            // Assert
            Assert.Equal(ratings, result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectRating()
        {
            // Arrange
            var rating = new Ratings { Id = 5, Score = 6 };
            _repositoryMock.Setup(r => r.GetByIdAsync(5))
                           .ReturnsAsync(rating);

            // Act
            var result = await _repositoryMock.Object.GetByIdAsync(5);

            // Assert
            Assert.Equal(5, result.Id);
            Assert.Equal(6, result.Score);
        }
    }
}
