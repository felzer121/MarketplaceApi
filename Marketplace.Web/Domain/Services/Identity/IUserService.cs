using System.Threading.Tasks;
using Marketplace.Web.Domain.Models.Identities;

namespace Marketplace.Web.Domain.Services.Identity
{
    public interface IUserService
    {
        Task<UserDto> Login(LoginDto request);
        Task<UserDto> Register(RegistrationDto request);
    }
}
