using Library.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IUserRepository userRepository;

        public LoginController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Post([FromBody] AuthRequest request) {

            var user = userRepository.FromEmail(request.Email);

            if(user != null && user.Password == request.Password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())

                };

                var token = GenerateTokenFromClaims(claims);
                return Ok(new { Token  = token });
            }

            return Unauthorized();

        }

        private string GenerateTokenFromClaims(List<Claim> claims)
        {
            string jwtToken = string.Empty;

            var key = Encoding.UTF8.GetBytes("This is a friday afternnon when the april sun is at the highest, It may reach 11 degrees");
            var securityKey = new SymmetricSecurityKey(key);
            var securityCred = new SigningCredentials(securityKey
                , SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                 issuer: "arangahttech.com",
                 claims: claims,
                 expires: DateTime.UtcNow.AddDays(7),
                 signingCredentials: securityCred
                );


            jwtToken= new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }

    public record AuthRequest
    {
        public string Email { get; set;}
        public string Password { get; set;}
    }
}
