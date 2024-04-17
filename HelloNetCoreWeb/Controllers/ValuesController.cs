using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAppLibarary.SMS;

namespace HelloNetCoreWeb.Controllers
{
   
    [ApiController]
    [Route("/api/values")]
    public class ValuesController : ControllerBase
    {
        private ISmsService smsService;

        public ValuesController(ISmsService smsService)
        {
            this.smsService = smsService;
        }

        public IActionResult Get()
        {
            return Ok(new { Message = "Hello There" });
        }
    }
}
