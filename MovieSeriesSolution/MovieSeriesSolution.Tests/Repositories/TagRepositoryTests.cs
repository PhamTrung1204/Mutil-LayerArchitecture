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
    public class TagRepositoryTests
    {
        private readonly Mock<ITagRepository> _repositoryMock;

        public TagRepositoryTests()
        {
            _repositoryMock = new Mock<ITagRepository>();
        }

        [Fact]
        public async Task AddAsync_ShouldCallAddAsync_WhenTagIsValid()
        {
            // Arrange
            var tag = new Tag { tag_id = 0, tag_name = "Action" };
            _repositoryMock.Setup(r => r.AddAsync(tag))
                           .Returns(Task.CompletedTask);

            // Act
            await _repositoryMock.Object.AddAsync(tag);

            // Assert
            _repositoryMock.Verify(r => r.AddAsync(tag), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfTags()
        {
            // Arrange
            var tags = new List<Tag>
            {
                new Tag { tag_id = 1, tag_name = "Action" },
                new Tag { tag_id = 2, tag_name = "Romance" }
            };
            _repositoryMock.Setup(r => r.GetAllAsync())
                           .ReturnsAsync(tags);

            // Act
            var result = await _repositoryMock.Object.GetAllAsync();

            // Assert
            Assert.Equal(tags, result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectTag()
        {
            // Arrange
            var tag = new Tag { tag_id = 10, tag_name = "Horror" };
            _repositoryMock.Setup(r => r.GetByIdAsync(10))
                           .ReturnsAsync(tag);

            // Act
            var result = await _repositoryMock.Object.GetByIdAsync(10);

            // Assert
            Assert.Equal(10, result.tag_id);
            Assert.Equal("Horror", result.tag_name);
        }
    }
}
