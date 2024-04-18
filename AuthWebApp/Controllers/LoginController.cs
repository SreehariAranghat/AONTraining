using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthWebApp.Controllers
{

    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email,string password)
        {
       
            if(email == "admin@gmail.com" &&  password == "abcd123")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,"Sreehari"),
                    new Claim(ClaimTypes.NameIdentifier,"1001"),
                    new Claim(ClaimTypes.Role,"Admin")
                };

                var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return Redirect("/");
            }
            else
            {
                ViewBag.Error = "Error";
                return View();
            }
        }
    }
}
