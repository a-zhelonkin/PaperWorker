using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Auth
{
    public static class AuthConstants
    {
        /// <summary>
        /// Имя куки с токеном авторизации
        /// </summary>
        public const string AuthCookieName = "auth.token";

        /// <summary>
        /// Имя заголовка с токеном авторизации
        /// </summary>
        public const string AuthHeaderName = "Authorization";

        /// <summary>
        /// Тип авторизации
        /// </summary>
        public const string AuthType = "Bearer";

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