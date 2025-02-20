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
    public class RatingControllerTests
    {
        private readonly Mock<IRatingService> _serviceMock;
        private readonly RatingController _controller;

        public RatingControllerTests()
        {
            _serviceMock = new Mock<IRatingService>();
            _controller = new RatingController(_serviceMock.Object);
        }

        [Fact]
        public async Task AddRating_ShouldReturnCreated_WhenRatingIsValid()
        {
            // Arrange
            var rating = new Ratings { UserId = 1, MovieSeriesId = 10, Score = 8 };
            _serviceMock.Setup(s => s.AddRatingAsync(rating))
                        .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.CreateRating(rating);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdResult.StatusCode);
        }

        [Fact]
        public async Task AddRating_ShouldReturnBadRequest_WhenValueIsInvalid()
        {
            // Arrange
            var rating = new Ratings { UserId = 1, MovieSeriesId = 10, Score = 15 };
            _serviceMock.Setup(s => s.AddRatingAsync(rating))
                        .ThrowsAsync(new System.ArgumentException("Rating must be between 0 and 10"));

            // Act
            var result = await _controller.CreateRating(rating);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequest.StatusCode);
            Assert.Equal("Rating must be between 0 and 10", badRequest.Value);
        }

        [Fact]
        public async Task GetAllRatings_ShouldReturnOk_WithListOfRatings()
        {
            // Arrange
            var mockRatings = new List<Ratings>
            {
                new Ratings { Id = 1, Score = 7 },
                new Ratings { Id = 2, Score = 9 },
            };
            _serviceMock.Setup(s => s.GetAllRatingsAsync())
                        .ReturnsAsync(mockRatings);

            // Act
            var result = await _controller.GetAllRatings();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(mockRatings, okResult.Value);
        }

        [Fact]
        public async Task GetRating_ShouldReturnOk_WhenFound()
        {
            // Arrange
            var rating = new Ratings { Id = 5, Score = 7 };
            _serviceMock.Setup(s => s.GetRatingByIdAsync(5))
                        .ReturnsAsync(rating);

            // Act
            var result = await _controller.GetRating(5);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedRating = Assert.IsType<Ratings>(okResult.Value);
            Assert.Equal(5, returnedRating.Id);
        }
    }
}
