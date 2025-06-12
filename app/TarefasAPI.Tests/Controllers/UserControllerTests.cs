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
    }
}