using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contrib
{
    public class Package
    {
        private HashSet<User> Users;
        public HashSet<User> users { get { return Users; } set { Users = value; } }

        private HashSet<File> Files;
        public HashSet<File> files { get { return Files; } set { Files = value; } }

        public void addUser(User u)
        {
            Users.Add(u);
        }

        public void removeUser(User u)
        {
            Users.Remove(u);
        }

        public void addFile(File f)
        {
            Files.Add(f);
        }

        public void removeFile(File f)
        {
            Files.Remove(f);
        }
    }
}
