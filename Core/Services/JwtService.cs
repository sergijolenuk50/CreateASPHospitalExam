using Core.Interfaces;
using Core.Models;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration configuation;
        private readonly UserManager<User> userManager;
        private readonly JwtOptions jwtOptions;
        public JwtService(IConfiguration configuation, UserManager<User> userManager, JwtOptions jwtOptions)
        {
        this.configuation = configuation;
            this.userManager = userManager;
            this.jwtOptions = jwtOptions;
        
        }
        public string CreateToken(IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwtOptions.Lifetime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IEnumerable<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email!)
            };

            if (user.Birthdate.HasValue)
                claims.Add(new Claim(ClaimTypes.DateOfBirth, user.Birthdate.ToString()!));

            var roles = userManager.GetRolesAsync(user).Result;
            claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            return claims;
        }
    }
}
