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
    public class TagServiceTests
    {
        private readonly Mock<ITagRepository> _tagRepoMock;
        private readonly TagService _tagService;

        public TagServiceTests()
        {
            _tagRepoMock = new Mock<ITagRepository>();
            _tagService = new TagService(_tagRepoMock.Object);
        }

        [Fact]
        public async Task AddTagAsync_ShouldCallRepositoryAddAsync()
        {
            // Arrange
            var tag = new Tag { tag_id = 0, tag_name = "Action" };
            _tagRepoMock.Setup(r => r.AddAsync(tag))
                        .Returns(Task.CompletedTask);

            // Act
            await _tagService.AddTagAsync(tag);

            // Assert
            _tagRepoMock.Verify(r => r.AddAsync(tag), Times.Once);
        }

        [Fact]
        public async Task GetAllTagsAsync_ShouldReturnListOfTags()
        {
            // Arrange
            var mockTags = new List<Tag>
            {
                new Tag { tag_id = 1, tag_name = "Action" },
                new Tag { tag_id = 2, tag_name = "Comedy" }
            };
            _tagRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(mockTags);

            // Act
            var result = await _tagService.GetAllTagsAsync();

            // Assert
            Assert.Equal(mockTags, result);
        }

        [Fact]
        public async Task GetTagByIdAsync_ShouldReturnTag()
        {
            // Arrange
            var tag = new Tag { tag_id = 10, tag_name = "Horror" };
            _tagRepoMock.Setup(r => r.GetByIdAsync(10))
                        .ReturnsAsync(tag);

            // Act
            var result = await _tagService.GetTagByIdAsync(10);

            // Assert
            Assert.Equal(tag, result);
        }
    }
}
