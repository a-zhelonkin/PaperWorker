using System.Threading.Tasks;
using Auth;
using Microsoft.AspNetCore.Http;

namespace Front.Middleware
{
    public class JwtFromCookieMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtFromCookieMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var cookie = context.Request.Cookies[AuthConstants.AuthCookieName];
            if (cookie != null)
            {
                if (!context.Request.Headers.ContainsKey(AuthConstants.AuthHeaderName))
                {
                    context.Request.Headers.Append(AuthConstants.AuthHeaderName, $"{AuthConstants.AuthType} {cookie}");
                }
            }

            await _next.Invoke(context);
        }
    }
}