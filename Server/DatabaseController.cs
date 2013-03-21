using System;
using System.Collections.Generic;
using System.Data;
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
                var query = from u in db.Users
                            where u.Email.Equals(email)
                            select u;
                return query.FirstOrDefault<User>();
            }
        }

        public static bool deleteUserByEmail(string email)
        {
            Contract.Requires(email != null);

            using (var db = new RentingContext())
            {
                try
                {
                    var u = new User() { Email = email };
                    db.Entry(u).State = EntityState.Deleted;
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
