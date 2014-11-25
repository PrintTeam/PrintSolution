using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace TP.Web.Framework.Security
{
    public class Encryption
    {
        public static String MD5(String toCryString)
        {
            MD5CryptoServiceProvider hashmd5= new MD5CryptoServiceProvider();
            return BitConverter.ToString(hashmd5.ComputeHash(Encoding.Default.GetBytes(toCryString))).Replace("-", "").ToLower();
        }
    }
}
