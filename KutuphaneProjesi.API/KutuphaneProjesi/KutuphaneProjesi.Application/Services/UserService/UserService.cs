using AutoMapper;
using KutuphaneProjesi.Application.Models.User;
using KutuphaneProjesi.Domain.Entities;
using KutuphaneProjesi.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace KutuphaneProjesi.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IRoleRepo _rolRepo;
        private readonly IUserRoleRepo _userRolRepo;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public UserService(IUserRepo userRepo, SignInManager<User> signInManager, IMapper mapper, IUserRoleRepo userRolRepo, IRoleRepo rolRepo)
        {
            _userRepo = userRepo;
            _rolRepo = rolRepo;
            _userRolRepo = userRolRepo;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<User> Login(LoginDto model)
        {
            var user = await _userRepo.GetDefaultAsync(x => x.UserName == model.UserName && x.Password == model.Password);

            if (user == null)
                return null;
            return user;

        }

        public async Task<UserWithRoleDto> GetUserWithRole(User user)
        {
            var userRole = await _userRolRepo.GetDefaultAsync(x => x.UserId == user.Id);
            var role = await _rolRepo.GetDefaultAsync(x => x.Id == userRole.RoleId);

            return new UserWithRoleDto { UserName = user.UserName, Role = role.Name };
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
