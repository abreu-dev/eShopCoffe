using eShopCoffe.Core.Security;
using eShopCoffe.Core.Security.Interfaces;
using eShopCoffe.Identity.Application.Services.Interfaces;
using eShopCoffe.Identity.Domain.Entities;
using eShopCoffe.Identity.Domain.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eShopCoffe.Identity.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtSettings _jwtSettings;

        public TokenService(IUserRepository userRepository,
                            IJwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
            _userRepository = userRepository;
        }

        public string GenerateAuthenticationToken(UserDomain user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.Expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public IAuthenticatedUser? ValidateToken(string? token)
        {
            if (string.IsNullOrEmpty(token)) return null;

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "Id").Value);
                var user = _userRepository.GetById(userId);

                if (user == null) return null;

                return new AuthenticatedUser(user.Id, user.Login, user.IsAdmin);
            }
            catch
            {
                return null;
            }
        }
    }
}
