using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserService.Models;
using UserService.Service;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] UserRegisterDto model)
        {
            var user = await _userService.RegisterAsync(model.Name, model.Email, model.Phone, model.Password);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserLoginDto model)
        {
            var user = await _userService.AuthenticateAsync(model.Email, model.Password);
            var token = _userService.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<User>> GetProfile()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var user = await _userService.GetUserByIdAsync(userId);
            return user == null ? NotFound() : Ok(user);
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
    }

    public class UserRegisterDto
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class UserLoginDto
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}