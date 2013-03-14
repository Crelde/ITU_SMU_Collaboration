using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contrib
{
    public class Package
    {
        private List<User> Users;
        public List<User> users { get { return Users; } set { Users = value; } }

        private List<File> Files;
        public List<File> files { get { return Files; } set { Files = value; } }

        public void addUser(User u)
        {
            if (!Users.Contains(u))
            {
                Users.Add(u);
            }
        }

        public void removeUser(User u)
        {
            Users.Remove(u);
        }

        public void addUser(File f)
        {
            Files.Add(f);
        }

        public void removeUser(File f)
        {
            Files.Remove(f);
        }
    }
}
