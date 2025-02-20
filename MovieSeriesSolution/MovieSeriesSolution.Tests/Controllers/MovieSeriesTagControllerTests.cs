using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieSeries.API.Controllers;
using MovieSeries.CoreLayer.Entities;
using MovieSeries.DataAccessLayer.Repositories.Interfaces;
using MovieSeries.ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeriesSolution.Tests.Controllers
{
    public class MovieSeriesTagControllerTests
    {
        private readonly Mock<IMovieSeriesTagService> _serviceMock;
        private readonly MovieSeriesTagController _controller;

        public MovieSeriesTagControllerTests()
        {
            // Tạo mock service
            _serviceMock = new Mock<IMovieSeriesTagService>();
            // Inject mock service vào controller
            _controller = new MovieSeriesTagController(_serviceMock.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOk_WithListOfAssociations()
        {
            // Arrange
            var mockList = new List<MovieSeriesTag>
            {
                new MovieSeriesTag { movie_series_id=1, tag_id=2 },
                new MovieSeriesTag { movie_series_id=1, tag_id=3 }
            };
            _serviceMock.Setup(s => s.GetAllAsync())
                        .ReturnsAsync(mockList);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(mockList, okResult.Value);
        }

        [Fact]
        public async Task Get_ShouldReturnOk_WhenFound()
        {
            // Arrange
            var association = new MovieSeriesTag { movie_series_id = 5, tag_id = 10 };
            _serviceMock.Setup(s => s.GetByIdsAsync(5, 10))
                        .ReturnsAsync(association);

            // Act
            var result = await _controller.Get(5, 10);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(association, okResult.Value);
        }

        [Fact]
        public async Task Get_ShouldReturnNotFound_WhenNull()
        {
            // Arrange
            _serviceMock.Setup(s => s.GetByIdsAsync(99, 99))
                        .ReturnsAsync((MovieSeriesTag)null);

            // Act
            var result = await _controller.Get(99, 99);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Create_ShouldReturnCreatedAtAction_WhenValid()
        {
            // Arrange
            var mst = new MovieSeriesTag { movie_series_id = 1, tag_id = 2 };
            _serviceMock.Setup(s => s.AddAsync(mst))
                        .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Create(mst);

            // Assert
            var created = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, created.StatusCode);
            Assert.Equal(mst, created.Value);
        }

        [Fact]
        public async Task Create_ShouldReturnBadRequest_WhenModelInvalid()
        {
            // Arrange
            var mst = new MovieSeriesTag { movie_series_id = 0, tag_id = 0 };
            // Mô phỏng trường hợp ModelState ko hợp lệ
            _controller.ModelState.AddModelError("movie_series_id", "Required");

            // Act
            var result = await _controller.Create(mst);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequest.StatusCode);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContent()
        {
            // Arrange
            _serviceMock.Setup(s => s.DeleteAsync(1, 2))
                        .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(1, 2);

            // Assert
            var noContent = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, noContent.StatusCode);
        }
    }
}
