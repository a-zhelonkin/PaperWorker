using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Api
{
    public static class AuthConstants
    {
        /// <summary>
        /// Ключ шифрования
        /// </summary>
        private const string Key = "2a34de59-f039-44f1-af66-7b8af93a2b64";

        /// <summary>
        /// Издатель токена
        /// </summary>
        public const string Issuer = "server";

        /// <summary>
        /// Потребитель токена
        /// </summary>
        public const string Audience = "client";

        /// <summary>
        /// Время жизни токена в секундах
        /// </summary>
        public const double Lifetime = 86400;

        public static SecurityKey SymmetricSecurityKey => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }
}