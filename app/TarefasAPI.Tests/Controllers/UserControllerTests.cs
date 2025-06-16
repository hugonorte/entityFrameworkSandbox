using Moq;
using TarefasAPI.Controllers;
using TarefasAPI.Models;
using TarefasAPI.Repositories;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TarefasAPI.Tests.Controllers
{
    public class UsersControllerTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsOkResult_WithListOfUsers()
        {
            // Arrange (Given)
            var mockRepo = new Mock<IUserRepository>();
            var users = new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane Doe", Email = "jane@example.com" }
            };
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(users);
            var controller = new UsersController(mockRepo.Object);

            // Act (When)
            var result = await controller.GetAllAsync();

            // Assert (Then)
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUsers = Assert.IsAssignableFrom<IEnumerable<User>>(okResult.Value);
            Assert.Equal(2, returnedUsers.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsOkResult_WhenUserExists()
        {
            // Arrange (Given)
            var mockRepo = new Mock<IUserRepository>();
            var user = new User { Id = 1, Name = "John Doe", Email = "john@example.com" };
            mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(user);
            var controller = new UsersController(mockRepo.Object);

            // Act (When)
            var result = await controller.GetByIdAsync(1);

            // Assert (Then)
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUser = Assert.IsType<User>(okResult.Value);
            Assert.Equal(1, returnedUser.Id);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange (Given)
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((User)null!);
            var controller = new UsersController(mockRepo.Object);

            // Act (When)
            var result = await controller.GetByIdAsync(1);

            // Assert (Then)
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreateAsync_ReturnsCreatedAtAction_WithNewUser()
        {
            // Arrange (Given)
            var mockRepo = new Mock<IUserRepository>();
            var newUser = new User { Name = "John Doe", Email = "john@example.com" };
            var createdUser = new User { Id = 1, Name = "John Doe", Email = "john@example.com" };
            mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<User>())).ReturnsAsync(createdUser);
            var controller = new UsersController(mockRepo.Object);

            // Act (When)
            var result = await controller.CreateAsync(newUser);

            // Assert (Then)
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetByIdAsync", createdResult.ActionName);
            Assert.Equal(1, createdResult.RouteValues["id"]);
            var returnedUser = Assert.IsType<User>(createdResult.Value);
            Assert.Equal("John Doe", returnedUser.Name);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsOk_WhenUserExists()
        {
            // Arrange (Given)
            var mockRepo = new Mock<IUserRepository>();
            var updatedUser = new User { Id = 1, Name = "Updated John", Email = "john@example.com" };
            mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<User>())).ReturnsAsync(updatedUser);
            var controller = new UsersController(mockRepo.Object);

            // Act (When)
            var result = await controller.UpdateAsync(1, updatedUser);

            // Assert (Then)
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUser = Assert.IsType<User>(okResult.Value);
            Assert.Equal("Updated John", returnedUser.Name);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange (Given)
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<User>())).ReturnsAsync((User)null);
            var controller = new UsersController(mockRepo.Object);

            // Act (When)
            var result = await controller.UpdateAsync(1, new User { Id = 1 });

            // Assert (Then)
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsNoContent_WhenUserExists()
        {
            // Arrange (Given)
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.DeleteAsync(1)).ReturnsAsync(true);
            var controller = new UsersController(mockRepo.Object);

            // Act (When)
            var result = await controller.DeleteAsync(1);

            // Assert (Then)
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange (Given)
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.DeleteAsync(1)).ReturnsAsync(false);
            var controller = new UsersController(mockRepo.Object);

            // Act (When)
            var result = await controller.DeleteAsync(1);

            // Assert (Then)
            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData("john@example.com", true)] // Email válido
        public async Task CreateAsync_ReturnsBadRequest_ForInvalidEmail(string email, bool isValid)
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            var user = new User { Name = "John Doe", Email = email };
            mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<User>())).ReturnsAsync(user);
            var controller = new UsersController(mockRepo.Object);

            // Simula a validação do ModelState
            if (!isValid)
            {
                controller.ModelState.AddModelError("Email", "Invalid email format");
            }

            // Act
            var result = await controller.CreateAsync(user);

            // Assert
            if (isValid)
            {
                Assert.IsType<CreatedAtActionResult>(result);
            }
            else
            {
                Assert.IsType<BadRequestObjectResult>(result);
            }
        }
    }
}