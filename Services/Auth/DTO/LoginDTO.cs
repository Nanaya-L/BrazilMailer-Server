using System.ComponentModel;

namespace Services
{
    public class LoginDTO
    {
        [DefaultValue("carlos.pasquali.dev@gmail.com")]
        public required string Email { get; set; }
        [DefaultValue("123123123")]
        public required string Password { get; set; }
    }
}
