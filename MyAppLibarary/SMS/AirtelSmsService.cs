using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppLibarary.SMS
{
    public class AirtelSmsService : ISmsService
    {
        public string SentSms(string mobileNumber, string message)
        {
            return $"Message Sent to {mobileNumber} through AIRTEL";
        }
    }
}
