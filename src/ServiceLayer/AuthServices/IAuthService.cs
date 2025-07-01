using CRM.NexPolicy.src.ViewLayer.DTOs.Agency;
using CRM.NexPolicy.src.ViewLayer.DTOs.Auth;

namespace CRM.NexPolicy.src.ServiceLayer.AuthServices
{
    public interface IAuthService
    {
        Task<bool> SignUpAsync(CreateAgencyDto dto);
        Task<LoginResponseDto?> LoginAsync(LoginDto dto);
    }
}
