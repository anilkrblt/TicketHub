using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Services;
using UserService.Service;
using System.Security.Claims;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]  
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
             try
            {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
            }
            catch (Exception ex)
            {
        return BadRequest(ex.Message);
            }
        }           

       [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] UserRegisterDto model)
        {
             try
            {
                var user = await _userService.RegisterAsync(model.Name, model.Email, model.Phone, model.Password);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
}

        // Kullanıcı giriş
        [HttpPost("authenticate")]
        public async Task<ActionResult<string>> Authenticate([FromBody] UserLoginDto model)
        {
            try
            {
                var user = await _userService.AuthenticateAsync(model.Email, model.Password);
                var token = _userService.GenerateJwtToken(user);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        // Kimlik doğrulama gerektiren bir endpoint (profil görüntüleme)
        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<User>> GetProfile()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
            {   
            return NotFound("Kullanıcı bulunamadı");
            }

            return Ok(user);
        }
    }

    // Kullanıcı kaydı için DTO
    public class UserRegisterDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
    }

    // Kullanıcı girişi için DTO
    public class UserLoginDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}