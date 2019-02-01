using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Database;
using Microsoft.IdentityModel.Tokens;

namespace Auth
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IUnitOfWork _unitOfWork;

        public TokenGenerator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string GetToken(string email, string password = null)
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

        private IReadOnlyCollection<Claim> GetClaims(string email, string password = null)
        {
            var user = _unitOfWork.UserRepository.GetWithRoles(email);
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