using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppLibarary.SMS
{
    public  interface ISmsService
    {
        string SentSms(string mobileNumber, string message);
    }
}
