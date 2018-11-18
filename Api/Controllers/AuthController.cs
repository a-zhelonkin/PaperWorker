using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using Api.Models;
using Database;
using Database.Extensions;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/token")]
        [ResponseType(typeof(string))]
        public IHttpActionResult Token([FromBody] Auth auth)
        {
            var identity = GetIdentity(auth.Username, auth.Password);
            if (identity == null)
            {
                return Unauthorized();
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                AuthConstants.Issuer,
                AuthConstants.Audience,
                identity,
                now,
                now.Add(TimeSpan.FromMinutes(AuthConstants.Lifetime)),
                new SigningCredentials(AuthConstants.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(encodedJwt);
        }

        private static IReadOnlyCollection<Claim> GetIdentity(string username, string password)
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
//                if (passwordHash == user.Password)
                {
                    return new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                    };
                }
            }

            return null;
        }
    }
}