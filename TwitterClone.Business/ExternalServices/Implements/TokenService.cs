using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Dtos.AuthDtos;
using TwitterClone.Business.ExternalServices.Interfaces;
using TwitterClone.Core.Entities;

namespace TwitterClone.Business.ExternalServices.Implements
{
    public class TokenService : ITokenService
    {
        IConfiguration _config {  get; }
        public TokenService(IConfiguration config)
        {
            _config = config;
        }
        public TokenDto CreateToken(AppUser user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.GivenName, user.Fullname));
            claims.Add(new Claim("Test", user.BirthDate.ToString()));

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            DateTime expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_config.GetSection("Jwt")?["ExpireMin"]));
            JwtSecurityToken jwt = new JwtSecurityToken(_config.GetSection("Jwt")?["Issuer"],
                _config.GetSection("Jwt")?["Audience"],
                claims,
                DateTime.UtcNow,
                expires,
                cred);

            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();
            var token = jwtHandler.WriteToken(jwt);
            return new TokenDto
            {
                Expires = expires,
                Token = token
            };
        }
    }
}
