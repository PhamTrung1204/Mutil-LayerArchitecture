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
        private readonly Mock<IMovieSeriesTagRepository> _repoMock;
        private readonly MovieSeriesTagController _controller;

        public MovieSeriesTagControllerTests()
        {
            _repoMock = new Mock<IMovieSeriesTagRepository>();
            _controller = new MovieSeriesTagController(_repoMock.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOk_WithListOfData()
        {
            // Arrange
            var mockList = new List<MovieSeriesTag>
            {
                new MovieSeriesTag { movie_series_id=1, tag_id=2 },
                new MovieSeriesTag { movie_series_id=1, tag_id=3 },
            };
            _repoMock.Setup(r => r.GetAllAsync())
                     .ReturnsAsync(mockList);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(mockList, okResult.Value);
        }

        [Fact]
        public async Task GetMST_ShouldReturnOk_WhenFound()
        {
            // Arrange
            var mst = new MovieSeriesTag { movie_series_id = 10, tag_id = 20 };
            _repoMock.Setup(r => r.GetByIdsAsync(10, 20))
                     .ReturnsAsync(mst);

            // Act
            var result = await _controller.GetMST(10, 20);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(mst, okResult.Value);
        }

        [Fact]
        public async Task GetMST_ShouldReturnNotFound_WhenNull()
        {
            // Arrange
            _repoMock.Setup(r => r.GetByIdsAsync(99, 99))
                     .ReturnsAsync((MovieSeriesTag)null);

            // Act
            var result = await _controller.GetMST(99, 99);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Create_ShouldReturnCreatedAtAction_WhenValid()
        {
            // Arrange
            var mst = new MovieSeriesTag { movie_series_id = 1, tag_id = 2 };
            _repoMock.Setup(r => r.AddAsync(mst))
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
            _controller.ModelState.AddModelError("movie_series_id", "Required");
            // Mô phỏng model state lỗi

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
            _repoMock.Setup(r => r.DeleteAsync(1, 2))
                     .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(1, 2);

            // Assert
            var noContent = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, noContent.StatusCode);
        }
    }
}
