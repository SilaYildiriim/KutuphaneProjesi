using KutuphaneProjesi.Application.Models.User;
using KutuphaneProjesi.Domain.Entities;

namespace KutuphaneProjesi.Application.Services.UserService
{
    public interface IUserService
    {
        Task<User> Login(LoginDto model);
        Task<UserWithRoleDto> GetUserWithRole(User user);
        Task Logout();
    }
}
