using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiddleWareDemo.Service;

namespace MiddleWareDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {
        private readonly ILogger<GreetingsController> logger;
        private IThemeService themeService;

        public GreetingsController(ILogger<GreetingsController> logger
            ,IThemeService service)
        {
            this.logger = logger;
            this.themeService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            logger.LogInformation($"User accessing the greeting controller");
            return Ok(themeService.ApplyTheme());
        }
    }
}
