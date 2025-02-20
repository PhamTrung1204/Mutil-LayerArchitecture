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
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _controller = new UserController(_userServiceMock.Object);
        }

        [Fact]
        public async Task CreateUser_ShouldReturnCreatedAtAction()
        {
            // Arrange
            var user = new User { user_id = 1, username = "Bob", email = "bob@example.com" };
            _userServiceMock.Setup(s => s.AddUserAsync(user))
                            .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.CreateUser(user);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdResult.StatusCode);
            Assert.Equal(user, createdResult.Value);
        }

        [Fact]
        public async Task GetAllUsers_ShouldReturnOkObjectResult()
        {
            // Arrange
            var mockUsers = new List<User> { new User { user_id = 1 }, new User { user_id = 2 } };
            _userServiceMock.Setup(s => s.GetAllUsersAsync())
                            .ReturnsAsync(mockUsers);

            // Act
            var result = await _controller.GetAllUsers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(mockUsers, okResult.Value);
        }

        [Fact]
        public async Task GetUser_ShouldReturnNotFound_WhenUserNotExist()
        {
            // Arrange
            _userServiceMock.Setup(s => s.GetUserByIdAsync(999))
                            .ReturnsAsync((User)null);

            // Act
            var result = await _controller.GetUser(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetUser_ShouldReturnOk_WhenUserFound()
        {
            // Arrange
            var user = new User { user_id = 10, username = "Charlie" };
            _userServiceMock.Setup(s => s.GetUserByIdAsync(10))
                            .ReturnsAsync(user);

            // Act
            var result = await _controller.GetUser(10);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(user, okResult.Value);
        }
    }
}
