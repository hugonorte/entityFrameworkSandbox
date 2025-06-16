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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] User user)
        {
            var createdUser = await _userRepository.CreateAsync(user);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] User user)
        {
            if (id != user.Id)
                return BadRequest();

            var updatedUser = await _userRepository.UpdateAsync(user);
            if (updatedUser == null)
                return NotFound();
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _userRepository.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}