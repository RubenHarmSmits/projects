using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using SogyoLunchApp;

namespace SogyoLunchApp.APIService
{
    public class JwtIssuer
    {
        public JwtOptions Options { get; set; }

        public JwtIssuer(JwtOptions options)
        {
            this.Options = options;
        }

        public string IssueToken(AppUser user, ICollection<string> roles)
        {
            var handler = new JwtSecurityTokenHandler();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            claims.AddRange(roles.Select(role => 
                new Claim(ClaimTypes.Role, role)
            ));

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = Options.Issuer,
                Audience = Options.Audience,
                SigningCredentials = Options.Credentials,
                Subject = new ClaimsIdentity(claims),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(30)
            });

            return handler.WriteToken(securityToken);
        }
    }
}