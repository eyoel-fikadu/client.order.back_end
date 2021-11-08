using IdentityModel.Client;
using Microsoft.IdentityModel.Tokens;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.Features.User.ViewModel;
using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MLA.OrderManagement.Infrustructure.Services
{
    public class TokenService : ITokenService
    {
        public string BuildToken(UserViewModel user)
        {
            var key = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["Jwt:Key"]);

            var allClaims = new Claim[] {
                new(ClaimTypes.GivenName, user.UserName),
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Surname, user.SurName),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Authentication, user.Id.ToString()),
                new(ClaimTypes.UserData, user.Id.ToString()),
                new(ClaimTypes.Thumbprint, user.Id.ToString()),
                new(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            
            var claims = new ClaimsIdentity(allClaims); user.Roles.ForEach(r =>
                {
                    claims.AddClaim(new Claim(ClaimTypes.Role, r));
                }); 
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.Now.AddSeconds(GetTokenExpiry()),
                SigningCredentials = credentials,
                Issuer = ConfigurationManager.AppSettings["Jwt:Issuer"],
                IssuedAt = DateTime.Now
            }; 
            
            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Task<TokenResponse> GetToken(string scope)
        {
            throw new NotImplementedException();
        }

        public int GetTokenExpiry()
        {
            return 300;
        }
        public bool IsTokenValid(string key, string issuer, string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = issuer,
                    ValidAudience = issuer,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool ValidateToken(string key, string issuer, string audience, string token)
        {
            throw new NotImplementedException();
        }
    }
}


