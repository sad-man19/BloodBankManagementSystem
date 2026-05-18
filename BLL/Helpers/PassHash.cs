using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Helpers
{
    public static class PassHash
    {
        public static string GetMd5(string input)
        {
            using (MD5 md5 = MD5.Create()) 
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
