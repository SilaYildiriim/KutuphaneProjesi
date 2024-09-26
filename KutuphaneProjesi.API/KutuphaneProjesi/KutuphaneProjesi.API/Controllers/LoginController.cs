using KutuphaneProjesi.Application.Models.User;
using KutuphaneProjesi.Application.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KutuphaneProjesi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public LoginController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userService.Login(model);

            if (user == null)
                return Unauthorized("Giriş başarısız");

            var userWithRole = await _userService.GetUserWithRole(user);
            var tokenString = GenerateJWT(userWithRole);
            return Ok(new { Token = tokenString, User = userWithRole, Aud = _configuration["JwtSettings:validAudience"] });
        }

        private string GenerateJWT(UserWithRoleDto userWithRole)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:secretKey"]));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            // Kullanıcı rolünü token'a ekliyoruz
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userWithRole.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, userWithRole.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:validIssuer"],
                audience: _configuration["JwtSettings:validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return Ok();
        }



    }
}
