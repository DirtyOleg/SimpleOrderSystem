using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilityLayer
{
    public static class MD5Helper
    {
        public static string EncryptString(string plainText)
        {
            //instead of directly storing the password in plain text into the database, convert it to encrypted string first
            //since this is just a practice project, more advance encrypted method is not the concert of this project, so used the MD5 hash in here as a encryted function

            byte[] plainTxtStream = Encoding.UTF8.GetBytes(plainText);

            MD5 md5 = MD5.Create();
            byte[] hashedTxtStream= md5.ComputeHash(plainTxtStream);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashedTxtStream)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
