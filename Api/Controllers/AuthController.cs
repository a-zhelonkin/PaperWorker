using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Api.Models;
using Database;
using Database.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("token")]
        public IActionResult Token([FromBody] Auth auth)
        {
            var claims = GetClaims(auth.Username, auth.Password);
            if (claims == null)
            {
                return Unauthorized();
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
            var encoded = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(encoded);
        }

        private static IReadOnlyCollection<Claim> GetClaims(string username, string password)
        {
            using (var context = new PaperWorkerDbContext())
            {
                var user = context.Get(username);
                if (user == null)
                {
                    return null;
                }

                var sha256 = new SHA256Managed();
                var passwordHash = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
                if (passwordHash == user.Password)
                {
                    return new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username)
                    };
                }
            }

            return null;
        }
    }
}