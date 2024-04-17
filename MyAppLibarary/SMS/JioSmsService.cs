using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppLibarary.SMS
{
    public class JIOSmsService : ISmsService
    {
        private readonly string hashCode;

        public JIOSmsService()
        {
            hashCode = this.GetHashCode().ToString();
        }
        public string SentSms(string mobileNumber, string message)
        {
            return $"Message Sent to {mobileNumber} through JIO {hashCode}";
        }
    }
}
