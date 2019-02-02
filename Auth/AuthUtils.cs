using System;
using System.Security.Cryptography;
using System.Text;

namespace Auth
{
    public static class AuthUtils
    {
        public static string ToSha256(this string str)
        {
            using (var sha256 = new SHA256Managed())
            {
                return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(str)));
            }
        }
    }
}