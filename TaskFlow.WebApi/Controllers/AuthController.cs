using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Insfrastructure.Identity;
using TaskFlow.Insfrastructure.Service;

namespace TaskFlow.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly JwtService _jwt;
        public AuthController(UserManager<AppUser> UserManager,
            SignInManager<AppUser> Sign, JwtService Jwt)
        {
            _userManager = UserManager;
            _signInManager = Sign;
            _jwt = Jwt;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(string username,string email,string password)
        {
            var user = new AppUser
            {
                UserName = username,
                Email = email,
                PasswordHash = password
            };
            var result = await _userManager.CreateAsync(user, password);
            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return BadRequest("Invalid User");
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, password,false);
            if (!result.Succeeded)
                return Unauthorized("Invalid Password");
            var token = _jwt.GenerateToken(user);
            return Ok(new
            {
                message = "Login Successfull"
            });
        }
    }
}
