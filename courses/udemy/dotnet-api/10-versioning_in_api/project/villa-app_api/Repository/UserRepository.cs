using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using villa_app_api.Data;
using villa_app_api.Models.Dtos;
using villa_app_api.Models.Entities;
using villa_app_api.Repository.IRepository;

namespace villa_app_api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private string secretKey;

        public UserRepository(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        public bool IsUniqueUser(string username)
        {
            var user = _db.LocalUsers.FirstOrDefault(x => x.UserName == username);   
            return user == null ? true : false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _db.LocalUsers
                .FirstOrDefault(x => x.UserName.ToLower() == loginRequestDTO.UserName.ToLower() && x.Password == loginRequestDTO.Password);
            if (user == null)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey); // converte a secret key em bytes

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = user
            };

            return loginResponseDTO;
        }

        public async Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            LocalUser user = new()
            {
                UserName = registrationRequestDTO.UserName,
                Password = registrationRequestDTO.Password,
                Name = registrationRequestDTO.Name,
                Role = registrationRequestDTO.Role
            }; // TODO: Implementar o auto mapper

            _db.LocalUsers.Add(user);
            await _db.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    }
}
