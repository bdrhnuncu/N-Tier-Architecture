using Kirala.com.Business.Abstract;
using Kirala.com.Entities.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kirala.com.Business.Utilities.JWT
{
    public class JwtHelper : IJwtHelper
    {
        IConfiguration _configuration;
        TokenOptions _tokenOptions;
        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        public AccessToken CreateToken(User user)
        {
            var claims = Claims(user);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var jwtSecurityToken = CreateJwtSecurityToken(_tokenOptions, claims, credentials);
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return new AccessToken()
            {
                Token = token,
                Expiration = DateTime.Now.AddMinutes(double.Parse(_tokenOptions.Expiration))
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, Claim[] claims, SigningCredentials credentials)
        {
            return new JwtSecurityToken
                (
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(double.Parse(tokenOptions.Expiration)),
                signingCredentials: credentials
                );
        }

        private Claim[] Claims(User user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //unique
            };
            return claims;
        }
    }
}
