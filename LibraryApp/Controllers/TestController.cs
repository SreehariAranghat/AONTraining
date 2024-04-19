using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        private readonly IConfiguration config;

        public TestController(IConfiguration config)
        {
            this.config = config;
        }

        public IActionResult Get()
        {
            var httpUser = HttpContext.User.Identity.Name;
            return Ok(httpUser);
        }
    }
}
