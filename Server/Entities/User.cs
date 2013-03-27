using System.ComponentModel.DataAnnotations;

namespace Server.Entities
{
    public class User
    {
        [Key, Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public UserType Type { get; set; }
    }
}
