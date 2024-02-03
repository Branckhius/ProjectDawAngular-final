using AutoMapper;
using ProjectDawAngular.Data.DTOs;
using ProjectDawAngular.Models;
using ProjectDawAngular.Helpers.JwtUtil;
using ProjectDawAngular.Models.Enums;
using ProjectDawAngular.Repositories.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ProjectDawAngular.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtUtils _jwtUtils;

        public UserService(IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
        }

        public async Task<User> GetById(int userId)
        {
            int id = Convert.ToInt32(userId);
            return await _userRepository.GetById(id);
        }

        public async Task<UserLoginResponse> Login(UserLoginDto userDto)
        {
            var user = await _userRepository.FindByUsername(userDto.UserName);

            if (user == null || !BCryptNet.Verify(userDto.Password, user.Password))
            {
                return null; // or throw exception
            }
            if (user == null) return null;

            var token = _jwtUtils.GenerateJwtToken(user);
            return new UserLoginResponse(user, token);
        }

        public async Task<bool> Register(UserRegisterDto userRegisterDto, Role userRole)
        {
            var userToCreate = new User
            {
                Username = userRegisterDto.UserName,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                Email = userRegisterDto.Email,
                Role = userRole,
                Password = BCryptNet.HashPassword(userRegisterDto.Password)
            };

            _userRepository.Create(userToCreate);
           return await _userRepository.SaveAsync();
        }
    }
}
