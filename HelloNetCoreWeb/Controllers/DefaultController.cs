using Microsoft.AspNetCore.Mvc;

namespace HelloNetCoreWeb.Controllers
{
    [Route("/home")]
    public class DefaultController : Controller
    {
        [HttpGet()]
        public IActionResult Index()
        {
            return View();
        }
    }
}
