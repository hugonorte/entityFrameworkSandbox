using Microsoft.AspNetCore.Mvc;
using TarefasAPI.Models;
using TarefasAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TarefasAPI.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }
    }
}