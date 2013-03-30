using System.Collections.Generic;
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

        public virtual List<Item> OwnedItems { get; set; }

        public static explicit operator User(DataContracts.User user)
        {
            if (user == null)
                return null;

            return new User
            {
                Email = user.Email,
                OwnedItems = new List<Item>(),
                Password = user.Password,
                Type = user.Type
            };
        }

        public static explicit operator DataContracts.User(User user)
        {
            if (user == null)
                return null;

            return new DataContracts.User
            {
                Email = user.Email,
                Password = user.Password,
                Type = user.Type
            };
        }
    }
}
