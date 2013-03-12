using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contrib
{
    public class User
    {

        //Vildbrad was here
        private string Email;
        public string email { get { return Email; } set { Email = value; } } // TODO: check if valid E-mail? crelde says: add regex to check if it looks like an email

        private string Password;
        public string password { get { return Password; } set { Password = value; } } // Any security?

        private string Name;
        public string name { get { return Name; } set { Name = value; } }

        private UserType Type;
        public UserType type { get { return Type; } set { Type = value; } }

        public enum UserType { standard, admin }

     }
}
