using Microsoft.Extensions.DependencyInjection;
using MyAppLibarary.SMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppLibarary.ForgotPassword
{
    public class PasswordService : IPasswordService
    {
        //I2 - INS2
        ISmsService smsService;
        public PasswordService([FromKeyedServices("airtel")] ISmsService smsService) {
            this.smsService = smsService;
        }

        public string ResetPassword()
        {
            return this.smsService.SentSms("00000", "Your password has been recently rest");
            
        }
    }
}
