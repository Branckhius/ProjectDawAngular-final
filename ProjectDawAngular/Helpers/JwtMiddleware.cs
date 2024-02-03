using ProjectDawAngular.Helpers.JwtUtil;
using ProjectDawAngular.Services.UserService;

namespace ProjectDawAngular.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtil)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtil.GetUserId(token);

            if (userId != null)
            {
                // Convertim Guid-ul la int, dar acest lucru ar trebui să fie adaptat la logica ta.
                int userIdAsInt = userId.Value.GetHashCode(); // Exemplu de conversie, ar trebui să adaptezi la logica ta.
                context.Items["User"] = await userService.GetById(userIdAsInt);
            }

            await _next(context);
        }

    }
}
