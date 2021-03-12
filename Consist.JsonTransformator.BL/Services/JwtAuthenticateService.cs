using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Consist.JsonTransformator.BL.DomainObjects;
using Consist.JsonTransformator.BL.DomainObjects.Settings;
using Consist.JsonTransformator.BL.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Consist.JsonTransformator.BL.Services
{
    public class JwtAuthenticateService: IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtAuthenticateService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        public string GetToken(AuthenticateDto authenticateDto)
        {
            if (string.IsNullOrEmpty(authenticateDto.UserName) && authenticateDto.Password == "123")
            {
                var token = GenerateToken(authenticateDto);
                return token;
            }

            return string.Empty;
        }

        private string GenerateToken(AuthenticateDto authenticateDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {new Claim("username", authenticateDto.UserName ?? "test")}),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
