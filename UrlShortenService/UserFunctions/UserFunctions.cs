using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrlShortenService.UserFunctions
{
    public class UserFunctions
    {
       
        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(i => i[random.Next(i.Length)]).ToArray());
        }


    }
}