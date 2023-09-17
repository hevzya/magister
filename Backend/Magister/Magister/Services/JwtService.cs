using Magister.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Magister.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        //private readonly IGenericRepository<RefreshToken> _tokenRepos;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(string email, Guid userId, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };

            if (roles.Count() != 0)
            {
                // Додаємо до токену всі наші ролі через кому (Admin, Teacher, User)
                claims.Add(new Claim(ClaimTypes.Role, roles.Aggregate((x, y) => x + "," + y)));
            }

            // Криптографія
            var configKey = _configuration["JwtKey"];
            if(configKey is null)
            {
                throw new ArgumentNullException(nameof(configKey));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));
            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //public async Task<string> GenerateRefreshToken(int userId)
        //{
        //    var refreshToken = await _tokenRepos.GetSingle(x => x.UserId == userId);

        //    if (refreshToken == null)
        //    {
        //        refreshToken = new RefreshToken
        //        {
        //            Token = Guid.NewGuid().ToString(),
        //            ExpirationDate = DateTime.Now.AddDays(30),
        //            UserId = userId
        //        };
        //        await _tokenRepos.Create(refreshToken);
        //    }
        //    else
        //    {
        //        refreshToken.Token = Guid.NewGuid().ToString();
        //        refreshToken.ExpirationDate = DateTime.Now.AddDays(30);
        //        await _tokenRepos.Update(refreshToken);
        //    }
        //    return refreshToken.Token;
        //}
    }
}
