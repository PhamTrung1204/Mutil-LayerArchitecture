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
    public class UserRepositoryTests
    {
        private readonly Mock<IUserRepository> _repositoryMock;

        public UserRepositoryTests()
        {
            _repositoryMock = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task AddAsync_ShouldCallAddAsync_WhenUserIsValid()
        {
            // Arrange
            var user = new User { username = "Bob", email = "bob@example.com" };
            _repositoryMock.Setup(r => r.AddAsync(user)).Returns(Task.CompletedTask);

            // Act
            await _repositoryMock.Object.AddAsync(user);

            // Assert
            _repositoryMock.Verify(r => r.AddAsync(user), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { user_id = 1, username = "Bob" },
                new User { user_id = 2, username = "Alice" }
            };
            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(users);

            // Act
            var result = await _repositoryMock.Object.GetAllAsync();

            // Assert
            Assert.Equal(users, result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectUser()
        {
            // Arrange
            var user = new User { user_id = 10, username = "Charlie" };
            _repositoryMock.Setup(r => r.GetByIdAsync(10)).ReturnsAsync(user);

            // Act
            var result = await _repositoryMock.Object.GetByIdAsync(10);

            // Assert
            Assert.Equal(10, result.user_id);
            Assert.Equal("Charlie", result.username);
        }
    }
}
