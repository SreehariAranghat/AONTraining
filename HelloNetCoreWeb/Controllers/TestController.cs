using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAppLibarary.ForgotPassword;
using MyAppLibarary.SMS;

namespace HelloNetCoreWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //I1 - INS1
        private ISmsService smsService;
        private IPasswordService passwordService;

       

        public TestController(ISmsService smsService,IPasswordService passwordService)
        {
            //Service Discovery
            this.smsService = smsService;
            this.passwordService = passwordService;
        }

        public IActionResult Get(string id)
        {
            //Password Service
            var smsResponse1 = smsService.SentSms(id, "Your OTP for Resetting the password");

            //Reset the password
            var smsResponse2 = this.passwordService.ResetPassword();

            return Ok(new { Response1 = smsResponse1, Response2 = smsResponse2 });
        }
    }
}
