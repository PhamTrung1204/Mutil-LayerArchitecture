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
            var rating = new Ratings { user_id = 1, movie_series_id = 10, rating = 15 }; // Sai

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() =>
                _ratingService.AddRatingAsync(rating));
        }

        [Fact]
        public async Task AddRatingAsync_ShouldCallRepositoryAdd_WhenValueIsValid()
        {
            // Arrange
            var rating = new Ratings { user_id = 1, movie_series_id = 10, rating = 8 };
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
                new Ratings { rating_id = 1, rating = 7 },
                new Ratings { rating_id = 2, rating = 9 },
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
            var rating = new Ratings { rating_id = 10, rating = 5 };
            _ratingRepoMock.Setup(r => r.GetByIdAsync(10))
                           .ReturnsAsync(rating);

            // Act
            var result = await _ratingService.GetRatingByIdAsync(10);

            // Assert
            Assert.Equal(10, result.rating_id);
            Assert.Equal(5, result.rating);
        }
    }
}
