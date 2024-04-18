using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Common.Helper
{
    public static class JWTHelper
    {
        // 生成JWT
        public static string GenerateToken(string secret, string userId, DateTime expireDate,string jtiString)
        {
            var secretBytes = Encoding.UTF8.GetBytes(secret);

            //Debug.WriteLine("UserID for JWT: " + userId);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
               // new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
               new Claim(JwtRegisteredClaimNames.Jti, jtiString)

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

        //======================================================================

        public static ClaimsPrincipal GetPrincipalFromToken(string refreshToken, string secret,bool isLifeToken)
                                                     //string token這邊傳入的token是refresh token
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = isLifeToken, 
               // 是否驗證期限

                ValidateIssuerSigningKey = true,
                ValidIssuer = "JonHuang",
                ValidAudience = "Audience",
                ClockSkew = TimeSpan.Zero, //沒有容許時間偏移(不給誤差)
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                ClaimsPrincipal principal = tokenHandler.ValidateToken(refreshToken, tokenValidationParameters, out SecurityToken validatedToken);
                return principal;
               //包含用户身份信息的 ClaimsPrincipal物件
            }
            catch (SecurityTokenExpiredException)
            {
                return null; // Token 已过期
            }
            //catch
            //{
            //    return null; 
            //}
        }















        // 验证JWT
        //public static JwtSecurityToken VerifyToken(string jwtToken, string secret)
        //{
        //    var tokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateIssuer = false, // 不验证发行者
        //        ValidateAudience = false, // 不验证观众
        //        ValidateLifetime = true, //如果JWT实际有过期时间，这里应为true
        //        ValidateIssuerSigningKey = true, // 验证签名密钥
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)) // 签名密钥
        //    };

        //    var handler = new JwtSecurityTokenHandler();
        //    SecurityToken validatedToken;
        //    try
        //    {
        //        var claimsPrincipal = handler.ValidateToken(jwtToken, tokenValidationParameters, out validatedToken);
        //        return (JwtSecurityToken)validatedToken;
        //    }
        //    catch (SecurityTokenException)
        //    {
        //        // 这里处理验证失败的情况，例如抛出异常或返回null
        //        throw;
        //    }
        //}









    }
}
