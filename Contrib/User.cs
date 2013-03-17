using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contrib
{
    /*
     * TODO - Consider overriding Equals(), HashCode() etc, in order to optimize for HashSets.
     */
    public class User
    {
        private string Email;
        // TODO - Use regex to check if the email is in fact valid.
        public string email { get { return Email; } set { Email = value; } }

        private string Password;
        // TODO - Consider security. Should it perhaps be hashed?
        public string password { get { return Password; } set { Password = value; } }

        private string Name;
        public string name { get { return Name; } set { Name = value; } }

        public enum UserType { standard, admin }

        private UserType Type;
        public UserType type { get { return Type; } set { Type = value; } }
     }
}
