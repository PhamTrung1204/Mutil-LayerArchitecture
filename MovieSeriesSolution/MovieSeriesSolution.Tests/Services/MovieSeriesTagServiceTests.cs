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
    public class MovieSeriesTagServiceTests
    {
        private readonly Mock<IMovieSeriesTagRepository> _repoMock;
        private readonly MovieSeriesTagService _service;

        public MovieSeriesTagServiceTests()
        {
            _repoMock = new Mock<IMovieSeriesTagRepository>();
            _service = new MovieSeriesTagService(_repoMock.Object);
        }

        [Fact]
        public async Task AddMSTAsync_ShouldCallRepositoryAdd()
        {
            // Arrange
            var mst = new MovieSeriesTag { movie_series_id = 1, tag_id = 2 };
            _repoMock.Setup(r => r.AddAsync(mst)).Returns(Task.CompletedTask);

            // Act
            await _service.AddAsync(mst);

            // Assert
            _repoMock.Verify(r => r.AddAsync(mst), Times.Once);
        }

        [Fact]
        public async Task GetAllMSTAsync_ShouldReturnList()
        {
            // Arrange
            var mockList = new List<MovieSeriesTag>
            {
                new MovieSeriesTag { movie_series_id=1, tag_id=2 },
                new MovieSeriesTag { movie_series_id=1, tag_id=3 }
            };
            _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(mockList);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(mockList, result);
        }

        [Fact]
        public async Task GetMSTByIdsAsync_ShouldReturnCorrectMST()
        {
            // Arrange
            var mst = new MovieSeriesTag { movie_series_id = 5, tag_id = 10 };
            _repoMock.Setup(r => r.GetByIdsAsync(5, 10))
                     .ReturnsAsync(mst);

            // Act
            var result = await _service.GetByIdsAsync(5, 10);

            // Assert
            Assert.Equal(5, result.movie_series_id);
            Assert.Equal(10, result.tag_id);
        }
    }
}
