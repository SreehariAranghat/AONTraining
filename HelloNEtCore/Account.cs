using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloNEtCore
{
    /* public class Account :IEquatable<Account>
     {
         public string Name { get; set; }
         public int AccountNumber { get; set; }

         public bool Equals(Account other)
         {
             return this.AccountNumber == other.AccountNumber;  
         }
     }*/

    public class Account
    {
        public string Name { get; set; }
        public int AccountNo { get; set; }

        public int Age { get; set; }
    }

    public record AppTheme(string baseColor, string font)
    {
        public string TextColor = "White";
    }



}
