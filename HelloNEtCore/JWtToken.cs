using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloNEtCore
{
    public record JWtToken
    {
        public string Token { get; init; }
        public DateTime ExpiryDate { get; init; }
    }

    public static class Authenticate
    {
        public static JWtToken SignIn(string username,string password)
        {
            var token = new JWtToken
            {
                Token = "ABCD12345",
                ExpiryDate = DateTime.Now.AddDays(7),
            };


            return token;
        }
    }
}
