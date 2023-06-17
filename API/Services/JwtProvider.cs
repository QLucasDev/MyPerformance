using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Interface;
using API.Models;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class JwtProvider : IJwtProvider
    {
        private readonly IConfiguration _config;

        public JwtProvider(IConfiguration config)
        {
            _config = config;
        }

        public string GetUserIdFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenObj = tokenHandler.ReadJwtToken(token);
            var userIdClaim = tokenObj.Claims.FirstOrDefault(claim => claim.Type == "UserId");

            if (userIdClaim != null)
            {
                return userIdClaim.Value;
            }

            return null;
        }
        public AuthenticatedResponse GetToken(List<Claim> claim)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("PasswordKey")));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _config["profile:http:applicationUrl"],
                audience: _config["profile:http:applicationUrl"],
                claims: claim,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return new AuthenticatedResponse { Token = tokenString };
        }
    }
}