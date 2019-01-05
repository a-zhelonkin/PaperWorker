using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Database;
using Database.Extensions;
using Microsoft.IdentityModel.Tokens;

namespace Auth
{
    public static class TokenGenerator
    {
        public static string GetToken(string email, string password = null)
        {
            var claims = GetClaims(email, password);
            if (claims == null)
            {
                return null;
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                AuthConstants.Issuer,
                AuthConstants.Audience,
                claims,
                now,
                now.Add(TimeSpan.FromMinutes(AuthConstants.Lifetime)),
                new SigningCredentials(AuthConstants.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private static IReadOnlyCollection<Claim> GetClaims(string email, string password = null)
        {
            using (var context = new PaperWorkerDbContext())
            {
                var user = context.GetUserRoles(email);
                if (user == null)
                {
                    return null;
                }

                if (!(password == null || user.Password == password.ToHash()))
                {
                    return null;
                }

                var claims = user.Roles
                    .Select(userRole => new Claim(ClaimsIdentity.DefaultRoleClaimType, userRole.Role.Name.ToString()))
                    .ToList();

                claims.Add(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email));

                return claims;
            }
        }
    }
}