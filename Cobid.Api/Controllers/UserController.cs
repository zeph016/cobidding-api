using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) => _userService = userService;

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<User>>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<ServiceResponse<User>>> GetUser(int userId)
        {
            var user = await _userService.GetUserAsync(userId);
            return Ok(user);
        }

        [HttpDelete("delete/{id}"), Authorize]
        public async Task<ActionResult<ServiceResponse<List<User>>>> DeleteUser(int userId)
        {
            var result = await _userService.DeleteUser(userId);
            return Ok(result);
        }

        [HttpPost, Authorize]
        public async Task<ActionResult<ServiceResponse<List<User>>>> AddUser(User user)
        {
            var result = await _userService.AddUser(user);
            return Ok(result);
        }

        [HttpPut, Authorize]
        public async Task<ActionResult<ServiceResponse<List<User>>>> Update(User user)
        {
            var result = await _userService.UpdateUser(user);
            return Ok(result);
        }
    }
}
