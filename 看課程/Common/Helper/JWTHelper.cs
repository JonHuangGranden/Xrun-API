using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Common.Helper
{
    public static class JWTHelper
    {
        // 生成JWT
        public static string GenerateToken(string secret, string userId, DateTime expireDate)
        {
         
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var token = new JwtSecurityToken(
                issuer: "JonHuang",
                audience: "Audience",
                claims: claims,
                expires: expireDate,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretBytes), SecurityAlgorithms.HmacSha256Signature)
                );
            return handler.WriteToken(token);
        }

        // 验证JWT
        public static JwtSecurityToken VerifyToken(string jwtToken, string secret)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false, // 不验证发行者
                ValidateAudience = false, // 不验证观众
                ValidateLifetime = true, //如果JWT实际有过期时间，这里应为true
                ValidateIssuerSigningKey = true, // 验证签名密钥
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)) // 签名密钥
            };

            var handler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;
            try
            {
                var claimsPrincipal = handler.ValidateToken(jwtToken, tokenValidationParameters, out validatedToken);
                return (JwtSecurityToken)validatedToken;
            }
            catch (SecurityTokenException)
            {
                // 这里处理验证失败的情况，例如抛出异常或返回null
                throw;
            }
        }
    }
}
