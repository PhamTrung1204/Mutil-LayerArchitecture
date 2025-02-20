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
    public class MovieSeriesTagRepositoryTests
    {
        private readonly Mock<IMovieSeriesTagRepository> _repositoryMock;

        public MovieSeriesTagRepositoryTests()
        {
            _repositoryMock = new Mock<IMovieSeriesTagRepository>();
        }

        [Fact]
        public async Task AddAsync_ShouldCallAddAsync_WhenMSTIsValid()
        {
            // Arrange
            var mst = new MovieSeriesTag
            {
                movie_series_id = 1,
                tag_id = 2
            };
            _repositoryMock.Setup(r => r.AddAsync(mst))
                           .Returns(Task.CompletedTask);

            // Act
            await _repositoryMock.Object.AddAsync(mst);

            // Assert
            _repositoryMock.Verify(r => r.AddAsync(mst), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfMST()
        {
            // Arrange
            var list = new List<MovieSeriesTag>
            {
                new MovieSeriesTag { movie_series_id=1, tag_id=2 },
                new MovieSeriesTag { movie_series_id=1, tag_id=3 },
            };
            _repositoryMock.Setup(r => r.GetAllAsync())
                           .ReturnsAsync(list);

            // Act
            var result = await _repositoryMock.Object.GetAllAsync();

            // Assert
            Assert.Equal(list, result);
        }

        [Fact]
        public async Task GetByIdsAsync_ShouldReturnCorrectMST()
        {
            // Arrange
            var mst = new MovieSeriesTag { movie_series_id = 5, tag_id = 10 };
            _repositoryMock.Setup(r => r.GetByIdsAsync(5, 10))
                           .ReturnsAsync(mst);

            // Act
            var result = await _repositoryMock.Object.GetByIdsAsync(5, 10);

            // Assert
            Assert.Equal(5, result.movie_series_id);
            Assert.Equal(10, result.tag_id);
        }
    }
}
