using MyDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppLibarary.SMS
{
    public class VodafoneSMSService : ISmsService
    {
        private IDataRepository _repository;

        public VodafoneSMSService(IDataRepository repository)
        {
            this._repository = repository;
        }

        public string SentSms(string mobileNumber, string message)
        {
            return $"Message Sent to {mobileNumber} through VODAFONE";
        }
    }
}
