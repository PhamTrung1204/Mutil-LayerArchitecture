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
    public class ReviewServiceTests
    {
        private readonly Mock<IReviewRepository> _reviewRepoMock;
        private readonly ReviewService _reviewService;

        public ReviewServiceTests()
        {
            _reviewRepoMock = new Mock<IReviewRepository>();
            _reviewService = new ReviewService(_reviewRepoMock.Object);
        }

        [Fact]
        public async Task AddReviewAsync_ShouldCallRepositoryAdd()
        {
            // Arrange
            var review = new Review { user_id = 1, movie_series_id = 2, review_text = "Nice!" };
            _reviewRepoMock.Setup(r => r.AddAsync(review))
                           .Returns(Task.CompletedTask);

            // Act
            await _reviewService.AddReviewAsync(review);

            // Assert
            _reviewRepoMock.Verify(r => r.AddAsync(review), Times.Once);
        }

        [Fact]
        public async Task GetAllReviewsAsync_ShouldReturnListOfReviews()
        {
            // Arrange
            var mockList = new List<Review>
            {
                new Review { review_id=1, review_text="A" },
                new Review { review_id=2, review_text="B" }
            };
            _reviewRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(mockList);

            // Act
            var result = await _reviewService.GetAllReviewsAsync();

            // Assert
            Assert.Equal(mockList, result);
        }

        [Fact]
        public async Task GetReviewByIdAsync_ShouldReturnCorrectReview()
        {
            // Arrange
            var review = new Review { review_id = 10, review_text = "Testing..." };
            _reviewRepoMock.Setup(r => r.GetByIdAsync(10)).ReturnsAsync(review);

            // Act
            var result = await _reviewService.GetReviewByIdAsync(10);

            // Assert
            Assert.Equal(review, result);
        }
    }
}
