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
    public class MovieControllerTests
    {
        private readonly Mock<IMovieService> _serviceMock;
        private readonly MovieController _controller;
        public MovieControllerTests()
        {
            _serviceMock = new Mock<IMovieService>();
            _controller = new MovieController(_serviceMock.Object);
        }
        [Fact]
        public async Task GetMovies_ReturnsOkResult_WithListOfMovies()
        {
            // Arrange
            var movies = new List<MoviesSeries> { new MoviesSeries {movie_series_id =1, title =
"Inception" }, new MoviesSeries {movie_series_id =2, title = "The Matrix" } };
            _serviceMock.Setup(s =>
           s.GetAllMoviesAsync()).ReturnsAsync(movies);
            // Act
            var result = await _controller.GetMovie(1);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(movies, okResult.Value);
        }
        [Fact]
        public async Task
       AddMovie_ReturnsCreatedAtActionResult_WhenMovieIsValid()
        {
            // Arrange
            var movie = new MoviesSeries
            {
                title = "Inception",
                genre = "Sci-Fi"
            };
            _serviceMock.Setup(s =>
           s.AddMovieAsync(movie)).Returns(Task.CompletedTask);
            // Act
            var result = await _controller.AddMovie(movie);
            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }
    }

}
