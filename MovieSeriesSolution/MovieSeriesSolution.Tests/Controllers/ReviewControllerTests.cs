using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieSeries.API.Controllers;
using MovieSeries.CoreLayer.Entities;
using MovieSeries.ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeriesSolution.Tests.Controllers
{
    public class ReviewControllerTests
    {
        private readonly Mock<IReviewService> _reviewServiceMock;
        private readonly ReviewController _controller;

        public ReviewControllerTests()
        {
            _reviewServiceMock = new Mock<IReviewService>();
            _controller = new ReviewController(_reviewServiceMock.Object);
        }

        [Fact]
        public async Task CreateReview_ShouldReturnCreatedAtAction_WhenValid()
        {
            // Arrange
            var review = new Review { user_id = 1, movie_series_id = 2, review_text = "Hello" };
            _reviewServiceMock.Setup(s => s.AddReviewAsync(review))
                              .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.CreateReview(review);

            // Assert
            var created = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, created.StatusCode);
            Assert.Equal(review, created.Value);
        }

        [Fact]
        public async Task GetAllReviews_ShouldReturnOk_WithListOfReviews()
        {
            // Arrange
            var mockReviews = new List<Review>
            {
                new Review { review_id=1 },
                new Review { review_id=2 }
            };
            _reviewServiceMock.Setup(s => s.GetAllReviewsAsync())
                              .ReturnsAsync(mockReviews);

            // Act
            var result = await _controller.GetAllReviews();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(mockReviews, okResult.Value);
        }

        [Fact]
        public async Task GetReview_ShouldReturnNotFound_WhenReviewNotExist()
        {
            // Arrange
            _reviewServiceMock.Setup(s => s.GetReviewByIdAsync(999))
                              .ReturnsAsync((Review)null);

            // Act
            var result = await _controller.GetReview(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetReview_ShouldReturnOk_WhenReviewFound()
        {
            // Arrange
            var review = new Review { review_id = 10, review_text = "Wow" };
            _reviewServiceMock.Setup(s => s.GetReviewByIdAsync(10))
                              .ReturnsAsync(review);

            // Act
            var result = await _controller.GetReview(10);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(review, okResult.Value);
        }
    }
}
