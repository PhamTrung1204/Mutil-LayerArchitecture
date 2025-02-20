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
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepoMock;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _userRepoMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepoMock.Object);
        }

        [Fact]
        public async Task AddUserAsync_ShouldCallRepositoryAdd()
        {
            // Arrange
            var user = new User { username = "Bob", email = "bob@example.com" };
            _userRepoMock.Setup(r => r.AddAsync(user)).Returns(Task.CompletedTask);

            // Act
            await _userService.AddUserAsync(user);

            // Assert
            _userRepoMock.Verify(r => r.AddAsync(user), Times.Once);
        }

        [Fact]
        public async Task GetAllUsersAsync_ShouldReturnListOfUsers()
        {
            // Arrange
            var mockList = new List<User>
            {
                new User { user_id = 1, username = "Alice" },
                new User { user_id = 2, username = "Bob" }
            };
            _userRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(mockList);

            // Act
            var result = await _userService.GetAllUsersAsync();

            // Assert
            Assert.Equal(mockList, result);
        }

        [Fact]
        public async Task GetUserByIdAsync_ShouldReturnCorrectUser()
        {
            // Arrange
            var user = new User {user_id = 10, username = "Charlie" };
            _userRepoMock.Setup(r => r.GetByIdAsync(10)).ReturnsAsync(user);

            // Act
            var result = await _userService.GetUserByIdAsync(10);

            // Assert
            Assert.Equal(10, result.user_id);
            Assert.Equal("Charlie", result.username);
        }
    }
}
