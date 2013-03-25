using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class DatabaseController
    {
        public static User getUserByEmail(string email)
        {
            Contract.Requires(email != null);

            using (var db = new RentingContext())
            {
                return db.Users.Find(email);
            }
        }

        public static bool addUser(User user)
        {
            Contract.Requires(user != null);

            if (getUserByEmail(user.Email) != null)
                return false;

            using (var db = new RentingContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
        }

        public static bool updateUser(User newUser)
        {
            Contract.Requires(newUser != null);

            using (var db = new RentingContext())
            {
                var oldUser = db.Users.Find(newUser.Email);
                if (oldUser == null)
                    return false;

                DbEntityEntry entry = db.Entry(oldUser);
                entry.CurrentValues.SetValues(newUser);
                db.SaveChanges();
                return true;
            }
        }

        public static bool deleteUserByEmail(string email)
        {
            Contract.Requires(email != null);

            using (var db = new RentingContext())
            {
                try
                {
                    db.Entry(db.Users.Find(email)).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static UserType getAccountType(string email)
        {
            Contract.Requires(email != null);

            return getUserByEmail(email).Type;
        }


        public static bool removeFile(int id)
        {
            Contract.Requires(id != null);

            using (var db = new RentingContext())
            {
                try
                {
                    db.Entry(db.Files.Find(id)).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }
    }
}
