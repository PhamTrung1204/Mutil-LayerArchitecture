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
    public class ReviewRepositoryTests
    {
        private readonly Mock<IReviewRepository> _repositoryMock;

        public ReviewRepositoryTests()
        {
            _repositoryMock = new Mock<IReviewRepository>();
        }

        [Fact]
        public async Task AddAsync_ShouldCallAddAsync_WhenReviewIsValid()
        {
            // Arrange
            var review = new Review
            {
                user_id = 1,
                movie_series_id = 2,
                review_text = "Great movie!"
            };
            _repositoryMock.Setup(r => r.AddAsync(review))
                           .Returns(Task.CompletedTask);

            // Act
            await _repositoryMock.Object.AddAsync(review);

            // Assert
            _repositoryMock.Verify(r => r.AddAsync(review), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfReviews()
        {
            // Arrange
            var reviews = new List<Review>
            {
                new Review { review_id = 1, user_id=1, movie_series_id=2, review_text="A" },
                new Review { review_id = 2, user_id=1, movie_series_id=3, review_text="B" }
            };
            _repositoryMock.Setup(r => r.GetAllAsync())
                           .ReturnsAsync(reviews);

            // Act
            var result = await _repositoryMock.Object.GetAllAsync();

            // Assert
            Assert.Equal(reviews, result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectReview()
        {
            // Arrange
            var review = new Review { review_id = 10, user_id = 2, movie_series_id = 3, review_text = "Hello" };
            _repositoryMock.Setup(r => r.GetByIdAsync(10))
                           .ReturnsAsync(review);

            // Act
            var result = await _repositoryMock.Object.GetByIdAsync(10);

            // Assert
            Assert.Equal(10, result.review_id);
            Assert.Equal("Hello", result.review_text);
        }
    }
}
