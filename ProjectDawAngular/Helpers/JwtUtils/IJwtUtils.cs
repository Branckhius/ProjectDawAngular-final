using ProjectDawAngular.Models;

namespace ProjectDawAngular.Helpers.JwtUtil
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid? GetUserId(string? token);
    }
}
