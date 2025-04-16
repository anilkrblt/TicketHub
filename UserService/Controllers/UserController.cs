using Microsoft.AspNetCore.Mvc;
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
            return Ok(new { Token = token , User = user});
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUser([FromRoute] int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }



        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
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