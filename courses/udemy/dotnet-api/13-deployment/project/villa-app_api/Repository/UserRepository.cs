using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager; // PROPRIEDADE DO ASP.NET IDENTITY COM BUILT INS PARA CONSULTAS DE USUÁRIO
        private readonly RoleManager<IdentityRole> _roleManager;
        private string secretKey;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext db, IConfiguration configuration, UserManager<ApplicationUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            _mapper = mapper;
        }

        public bool IsUniqueUser(string username)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(x => x.UserName == username);   
            return user == null ? true : false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _db.ApplicationUsers
                .FirstOrDefault(x => x.UserName.ToLower() == loginRequestDTO.UserName.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

            if (user == null || isValid == false)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };
            }

            var roles = await _userManager.GetRolesAsync(user);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey); // converte a secret key em bytes

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault()) // CASO HAJA MAIS DE UMA PODEMOS UTILIZAR UM FOREACH
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = _mapper.Map<UserDTO>(user),
            };

            return loginResponseDTO;
        }

        public async Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            //ApplicationUser user = new()
            //{
            //    UserName = registrationRequestDTO.UserName,
            //    Email = registrationRequestDTO.UserName,
            //    NormalizedEmail = registrationRequestDTO.UserName.ToUpper(),
            //    Name = registrationRequestDTO.Name
            //}; // TODO: Implementar o auto mapper

            ApplicationUser user = _mapper.Map<ApplicationUser>(registrationRequestDTO);

            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDTO.Password);
                if (result.Succeeded) 
                {
                    if (!_roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
                    {
                        await _roleManager.CreateAsync(new IdentityRole("admin"));
                        await _roleManager.CreateAsync(new IdentityRole("customer"));
                    }
                    await _userManager.AddToRoleAsync(user, "admin");

                    var userToReturn = _db.ApplicationUsers.FirstOrDefault(x => x.UserName == registrationRequestDTO.UserName);

                    return _mapper.Map<UserDTO>(userToReturn);
                }
            }
            catch (Exception ex)
            {

            }

            return new UserDTO();
        }
    }
}
