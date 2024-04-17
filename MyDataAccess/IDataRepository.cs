using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccess
{
    public interface IDataRepository
    {
        string ReadId(string id);
    }
}
