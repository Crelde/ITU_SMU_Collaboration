using Server.Entities;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Server
{
    public class DatabaseController
    {
        public static bool CreateUser(User newUser)
        {
            Contract.Requires(GetUserByEmail(newUser.Email) == null);
            Contract.Ensures(GetUserByEmail(newUser.Email).Equals(newUser));

            using (var db = new RentingContext())
            {
                if (db.Users.Find(newUser.Email) != null)
                    return false;

                db.Users.Add(newUser);
                db.SaveChanges();
                return true;
            }
        }

        [Pure]
        public static User GetUserByEmail(string email)
        {
            Contract.Requires(email != null);
            Contract.Ensures(Contract.Result<User>().Email.Equals(email));

            using (var db = new RentingContext())
            {
                return db.Users.Find(email);
            }
        }

        public static bool UpdateUser(User newUser)
        {
            Contract.Requires(GetUserByEmail(newUser.Email) != null);
            Contract.Ensures(GetUserByEmail(newUser.Email).Equals(newUser));

            using (var db = new RentingContext())
            {
                if (db.Users.Find(newUser.Email) == null)
                    return false;

                var oldUser = db.Users.Find(newUser.Email);
                db.Entry(oldUser).CurrentValues.SetValues(newUser);
                db.SaveChanges();
                return true;
            }
        }

        public static bool DeleteUserByEmail(string email)
        {
            Contract.Requires(email != null);
            Contract.Ensures(GetUserByEmail(email) == null);

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

        [Pure]
        public static UserType getAccountType(string email)
        {
            Contract.Requires(email != null);
            return GetUserByEmail(email).Type;
        }



        public static bool CreatePackage(Package newPackage)
        {
            using (var db = new RentingContext())
            {
                try
                {
                    db.Packages.Add(newPackage);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        [Pure]
        public static Package GetPackageById(int id)
        {            
            using (var db = new RentingContext())
            {
                return db.Packages.Find(id);
            }
        }

        public static bool DeletePackageById(int id)
        {
            using (var db = new RentingContext())
            {
                try
                {
                    db.Entry(db.Packages.Find(id)).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        private static bool AlterPackageFiles(List<int> fIds, int pId, bool remove)
        {
            using (var db = new RentingContext())
            {
                var package = db.Packages.Find(pId);
                if (package == null)
                    return false;
                foreach (var fId in fIds)
                {
                    var file = db.Files.Find(fId);
                    if (file == null)
                        return false;
                    if (remove)
                    {
                        package.Files.Remove(file);
                    }
                    else
                    {
                        package.Files.Add(file);
                    }
                }
                db.SaveChanges();
                return true;
            }
        }

        public static bool AddToPackage(List<int> fIds, int pId)
        {
            return AlterPackageFiles(fIds, pId, false);   
        }

        public static bool RemoveFromPackage(List<int> fIds, int pId)
        {
            return AlterPackageFiles(fIds, pId, true);
        }

        [Pure]
        public static RightsType GetRightsForFile(int fileId, string email)
        {
            using (var db = new RentingContext())
            {
                return db.Rights.Find(email, fileId).Type;
            }
        }


        public static bool SharePackage(int pId, List<string> emails)
        {
            using (var db = new RentingContext())
            {
                var package = db.Packages.Find(pId);
                if (package == null)
                    return false;
                foreach (var email in emails)
                {
                    var user = db.Users.Find(email);
                    if (user == null)
                        return false;
                    var right = db.Rights.Find(email, pId);
                    if (right != null)
                        return false;
                    right = new Right { Package = package, User = user };
                    db.Rights.Add(right);
                }
                db.SaveChanges();
                return true;
            }            
        }

        public static List<Package> GetPackagesByEmail(string email)
        {
            using (var db = new RentingContext())
            {
                var list = new List<Package>();
                list.AddRange(from right in db.Rights where right.User.Email.Equals(email) select right.Package);
                return list;
            }
        }
        public static bool RemoveTag(int fileId, string tag)
        {
            using (var db = new RentingContext())
            {
                var file = db.Files.Find(fileId);
                if (file == null)
                    return false;
                var tags = file.Tags;
                if (!tags.Any(t => t.Text.Equals(tag)))
                    return false;
                tags.Remove(tags.Single(t => t.Text.Equals(tag)));
                db.SaveChanges();
            }
            return true;
        }
        public static bool AddTag(int fileId,string tag)
        {
            using (var db = new RentingContext())
            {
                var file = db.Files.Find(fileId);
                if (file == null)
                    return false;
                var tags = file.Tags;
                if (tags.Any(t => t.Text.Equals(tag)))
                    return false;
                tags.Add(new Tag { Text = tag });
                db.SaveChanges();
            }
            return true;
        }


        public static bool CreateFile(File newFile)
        {
            try
            {
                using (var db = new RentingContext())
                {
                    db.Files.Add(newFile);
                    db.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static File GetFileById(int id)
        {
            using (var db = new RentingContext())
            {
                return db.Files.Find(id);
            }
        }

        public static bool ReplaceFile(File newFile)
        {
            try
            {
                using (var db = new RentingContext())
                {
                    db.Entry(db.Files.Find(newFile.Id)).CurrentValues.SetValues(newFile);
                    db.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool RemoveFileById(int id)
        {
            try
            {
                using (var db = new RentingContext())
                {
                    db.Entry(db.Files.Find(id)).State = EntityState.Deleted;
                    db.SaveChanges();                   
                }
            }
            catch {
                return false;
            }
            return true;
        }
    }
}
