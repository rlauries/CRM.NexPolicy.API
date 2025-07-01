using CRM.NexPolicy.src.DataLayer.Models.Auth;
using CRM.NexPolicy.src.DataLayer.Repository.AuthRepository;
using CRM.NexPolicy.src.ServiceLayer.AgencyServices;
using CRM.NexPolicy.src.ServiceLayer.Agent;
using CRM.NexPolicy.src.ViewLayer.DTOs.Agency;
using CRM.NexPolicy.src.ViewLayer.DTOs.Auth;
using CRM.NexPolicy.src.ViewLayer.DTOs.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRM.NexPolicy.src.ServiceLayer.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly JwtSettings _jwtSettings;
        private readonly IAgencyService _agencyService;
        private readonly IAgentService _agentService;


        public AuthService(IAuthRepository authRepository,
                           IOptions<JwtSettings> jwtSettings,
                           IAgencyService agencyService,
                           IAgentService agentService)
        {
            _authRepository = authRepository;
            _jwtSettings = jwtSettings.Value;
            _agencyService = agencyService;
            _agentService = agentService;

        }


        public async Task<bool> SignUpAsync(CreateAgencyDto dto)
        {
            // Validación de email existente
            if (await _authRepository.UserExistsAsync(dto.Email)) return false;


            CreatePasswordHash(dto.Password, out byte[] hash, out byte[] salt);

            var user = new UserModel
            {
                Email = dto.Email,
                PasswordHash = hash,
                PasswordSalt = salt,
                CreatedDate = DateTime.UtcNow,
                RoleId = 1
                
            };

            // Guardar el usuario en la base de datos
            await _authRepository.AddUserAsync(user);
            await _authRepository.SaveChangesAsync();

            

            await _agencyService.CreateAgencyWithIdAsync(user.Id,user.Email, dto.BusinessName, dto.ProfileImageUrl);


            // Actualizar AgencyId en el usuario
            user.AgencyId = user.Id;
            await _authRepository.SaveChangesAsync();

            return true;
        }


        public async Task<LoginResponseDto?> LoginAsync(LoginDto dto)
        {
            var user = await _authRepository.GetUserByEmailAsync(dto.Email);
            if (user == null || !VerifyPassword(dto.Password, user.PasswordHash, user.PasswordSalt))
                throw new UnauthorizedAccessException("Invalid credentials.");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.Role),
                    new Claim("AgencyId", user.AgencyId?.ToString() ?? ""),
                    new Claim("AgentId", user.AgentId?.ToString() ?? ""),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),

                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _jwtSettings.Issuer,        // Nuevo
                Audience = _jwtSettings.Audience,    // Nuevo
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);
            return new LoginResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                BusinessName = user.Agency?.BusinessName,
                Role = user.Role.Role,
                Token = jwt,
                AgencyId = user.AgencyId,
                AgentId = user.AgentId
            };
        }

        private void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            salt = hmac.Key;
            hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyPassword(string password, byte[] hash, byte[] salt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(salt);
            var computed = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computed.SequenceEqual(hash);
        }


    }
}
