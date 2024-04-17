using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MiddleWareDemo.Service;

namespace MiddleWareDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        ThemeSettings theme;

        public ValuesController(IOptions<ThemeSettings> theme)
        {
            this.theme = theme.Value;
        }

        public IActionResult Get()
        {
            return Ok(theme.Color);
        }
    }
}
