using Microsoft.AspNetCore.Mvc;

namespace HelloNetCoreWeb.Controllers
{
    [Route("/about")]
    public class AboutUsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
