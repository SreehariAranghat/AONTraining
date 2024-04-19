using Library.Data;
using LibraryApp.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter<AuthExceptionFilter>]
    public class LoginController : ControllerBase
    {
        IUserRepository userRepository;

        public LoginController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        [ProducesDefaultResponseType(typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        ///<summary>
        /// Login Url
        /// Email and password must be non null
        /// </summary>
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

    /// <summary>
    /// Authentication Request
    /// </summary>
    public record AuthRequest
    {
        /// <summary>
        /// Email Address. Must be of domain @mycompany.com
        /// </summary>
        /// <remarks>Email must be validated at the clients end</remarks>
        public string Email { get; set;}

        /// <summary>
        /// Password or Token for the user. 
        /// Must be 8 characters
        /// </summary>
        public string Password { get; set;}
    }
}
