using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BookingWebApp.BusinessLogic.Interfaces;

namespace BookingWebApp.BusinessLogic.BusinessLogicClasses
{
    public static class HashProvider
    {
        public static string GetHash(string password)
        {
            SHA512 sha512 = SHA512.Create();
            var hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
    }
}
