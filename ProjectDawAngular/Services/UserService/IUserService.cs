
using ProjectDawAngular.Data.DTOs;
using ProjectDawAngular.Models;
using ProjectDawAngular.Models.Enums;

namespace ProjectDawAngular.Services.UserService
{
    public interface IUserService
    {
        Task<UserLoginResponse> Login(UserLoginDto user);
        Task<User> GetById(int userId);

        Task<bool> Register(UserRegisterDto userRegisterDto, Role userRole);
    }
}
