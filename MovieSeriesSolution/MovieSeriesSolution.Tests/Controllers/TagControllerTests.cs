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
    public class TagControllerTests
    {
        private readonly Mock<ITagService> _tagServiceMock;
        private readonly TagController _controller;

        public TagControllerTests()
        {
            _tagServiceMock = new Mock<ITagService>();
            _controller = new TagController(_tagServiceMock.Object);
        }

        [Fact]
        public async Task CreateTag_ShouldReturnCreated_WhenTagIsValid()
        {
            // Arrange
            var tag = new Tag { tag_id = 0, tag_name = "Action" };
            _tagServiceMock.Setup(s => s.AddTagAsync(tag))
                           .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.CreateTag(tag);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdResult.StatusCode);
            Assert.Equal(tag, createdResult.Value);
        }

        [Fact]
        public async Task GetAllTags_ShouldReturnOkObjectResult()
        {
            // Arrange
            var mockTags = new List<Tag>
            {
                new Tag { tag_id = 1, tag_name = "Comedy" },
                new Tag { tag_id = 2, tag_name = "Drama" }
            };
            _tagServiceMock.Setup(s => s.GetAllTagsAsync())
                           .ReturnsAsync(mockTags);

            // Act
            var result = await _controller.GetAllTags();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(mockTags, okResult.Value);
        }

        [Fact]
        public async Task GetTag_ShouldReturnNotFound_WhenTagNotExists()
        {
            // Arrange
            _tagServiceMock.Setup(s => s.GetTagByIdAsync(999))
                           .ReturnsAsync((Tag)null);

            // Act
            var result = await _controller.GetTag(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetTag_ShouldReturnOk_WhenTagExists()
        {
            // Arrange
            var tag = new Tag { tag_id = 10, tag_name = "Horror" };
            _tagServiceMock.Setup(s => s.GetTagByIdAsync(10))
                           .ReturnsAsync(tag);

            // Act
            var result = await _controller.GetTag(10);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(tag, okResult.Value);
        }
    }
}
