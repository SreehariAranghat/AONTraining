using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccess
{
    public class SqlDataRepository : IDataRepository
    {
        public string ReadId(string id)
        {
            return $"Data read from SQL SErver";
        }
    }
}
