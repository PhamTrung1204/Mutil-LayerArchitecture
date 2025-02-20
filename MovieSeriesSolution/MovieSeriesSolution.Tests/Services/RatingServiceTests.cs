using Moq;
using MovieSeries.CoreLayer.Entities;
using MovieSeries.DataAccessLayer.Repositories.Interfaces;
using MovieSeries.ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeriesSolution.Tests.Services
{
    public class RatingServiceTests
    {
        private readonly Mock<IRatingRepository> _ratingRepoMock;
        private readonly RatingService _ratingService;

        public RatingServiceTests()
        {
            _ratingRepoMock = new Mock<IRatingRepository>();
            _ratingService = new RatingService(_ratingRepoMock.Object);
        }

        [Fact]
        public async Task AddRatingAsync_ShouldThrowException_WhenValueIsInvalid()
        {
            // Arrange
            var rating = new Ratings { UserId = 1, MovieSeriesId = 10, Score = 15 }; // Sai

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() =>
                _ratingService.AddRatingAsync(rating));
        }

        [Fact]
        public async Task AddRatingAsync_ShouldCallRepositoryAdd_WhenValueIsValid()
        {
            // Arrange
            var rating = new Ratings { UserId = 1, MovieSeriesId = 10, Score = 8 };
            _ratingRepoMock.Setup(r => r.AddAsync(rating))
                           .Returns(Task.CompletedTask);

            // Act
            await _ratingService.AddRatingAsync(rating);

            // Assert
            _ratingRepoMock.Verify(r => r.AddAsync(rating), Times.Once);
        }

        [Fact]
        public async Task GetAllRatingsAsync_ShouldReturnListOfRatings()
        {
            // Arrange
            var mockRatings = new List<Ratings>
            {
                new Ratings { Id = 1, Score = 7 },
                new Ratings { Id = 2, Score = 9 },
            };
            _ratingRepoMock.Setup(r => r.GetAllAsync())
                           .ReturnsAsync(mockRatings);

            // Act
            var result = await _ratingService.GetAllRatingsAsync();

            // Assert
            Assert.Equal(mockRatings, result);
        }

        [Fact]
        public async Task GetRatingByIdAsync_ShouldReturnRating()
        {
            // Arrange
            var rating = new Ratings { Id = 10, Score = 5 };
            _ratingRepoMock.Setup(r => r.GetByIdAsync(10))
                           .ReturnsAsync(rating);

            // Act
            var result = await _ratingService.GetRatingByIdAsync(10);

            // Assert
            Assert.Equal(10, result.Id);
            Assert.Equal(5, result.Score);
        }
    }
}
