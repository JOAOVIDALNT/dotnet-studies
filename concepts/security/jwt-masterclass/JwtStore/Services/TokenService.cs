using JwtStore.Models;
using System.IdentityModel.Tokens.Jwt;

namespace JwtStore.Services
{
    public class TokenService
    {
        public string Create(User user)
        {
            var handler = new JwtSecurityTokenHandler();

            var token = handler.CreateToken();

            return handler.WriteToken(token);

        }
    }
}
