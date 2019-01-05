using System;
using System.Security.Cryptography;
using System.Text;

namespace Auth
{
    public static class AuthUtils
    {
        public static string ToHash(this string str)
        {
            var buffer = Encoding.UTF8.GetBytes(str);
            var sha256 = new SHA256Managed();
            var hash = sha256.ComputeHash(buffer);
            return Convert.ToBase64String(hash);
        }
    }
}