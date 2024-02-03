using System.ComponentModel.DataAnnotations;

namespace ProjectDawAngular.Data.DTOs
{
    public class UserLoginDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
