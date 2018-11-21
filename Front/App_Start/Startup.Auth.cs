using System;
using Api;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.Jwt;
using Owin;

namespace Front
{
    public partial class Startup
    {
        private static void ConfigureAuth(IAppBuilder app)
        {
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = AuthConstants.GetSymmetricSecurityKey(),
                    ValidIssuer = AuthConstants.Issuer,
                    ValidAudience = AuthConstants.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(0)
                }
            });
        }
    }
}