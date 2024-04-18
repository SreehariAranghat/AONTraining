using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoItemLibrary
{
    public interface IToDoItemService
    {
        List<string> GetToDoItemsForCurrentUser();
    }
}
