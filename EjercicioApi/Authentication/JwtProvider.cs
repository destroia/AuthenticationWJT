using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace EjercicioApi.Authentication
{
    public class JwtProvider : ITokenProvider
    {
        RsaSecurityKey Key;
        string Algoritmo;
        string Issuer;
        string Audience;
        public JwtProvider(string issuer, string audience, string keyName)
        {
            var param = new CspParameters()
            {
                KeyContainerName = keyName
            };

            var provider = new RSACryptoServiceProvider(2048, param);

            Key = new RsaSecurityKey(provider);
            Algoritmo = SecurityAlgorithms.RsaSha256Signature;
            Issuer = issuer;
            Audience = audience;



        }
        public string CreateToken(User user, DateTime expiry)
        {
            JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();
            user.FirstName = "david";
            user.LastName = "bedoya";
            user.Roles = "1";
            var identity = new ClaimsIdentity(new List<Claim>() {
                new Claim(ClaimTypes.Name,user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Role,user.Roles),
                new Claim(ClaimTypes.PrimarySid,user.Id.ToString())
            },"Customer");

            SecurityToken Token = TokenHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor()
            {
                Audience = Audience,
                Issuer = Issuer,
                SigningCredentials = new SigningCredentials(Key, Algoritmo),
                Expires = expiry.ToUniversalTime(),
                Subject = identity
            });
            return TokenHandler.WriteToken(Token);
        }

        public TokenValidationParameters GetTokenValidation()
        {
            return new TokenValidationParameters()
            {
                IssuerSigningKey = Key,
                ValidAudience = Audience,
                ValidIssuer = Issuer,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(0)
            };
        }
    }
}
