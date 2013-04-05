using Server.Entities;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Server
{
    public class DatabaseController
    {
        public static void CreateUser(DataContracts.User newUser)
        {
            Contract.Requires(newUser.Email != null);
            Contract.Requires(GetUserByEmail(newUser.Email) == null);
            Contract.Ensures(GetUserByEmail(newUser.Email).Equals(newUser));

            using (var db = new DatabaseContext())
            {
                try
                {
                    db.Users.Add((User)newUser);
                    db.SaveChanges();
                }

                // We should set something up that informs the user that the user was not added
                // But im not quite sure how to do that yet, since we haven't talked about the client yet
                catch (DataException e)
                {
                    return;
                }
                finally
                {
                // In the same fashion we could tell the user that it succeded, 
                }
            }
        }

        // This method returns null if no user exists by that email.
        [Pure]
        public static DataContracts.User GetUserByEmail(string email)
        {
            Contract.Requires(email != null);
            Contract.Ensures(Contract.Result<User>().Email.Equals(email));

            using (var db = new DatabaseContext())
            {
                return (DataContracts.User)db.Users.Find(email);
            }
        }

        public static void UpdateUser(DataContracts.User updatedUser)
        {
            Contract.Requires(updatedUser.Email != null);
            Contract.Requires(GetUserByEmail(updatedUser.Email) != null);
            Contract.Ensures(GetUserByEmail(updatedUser.Email).Equals(updatedUser));

            using (var db = new DatabaseContext())
            {
                var outdatedUser = db.Users.Find(updatedUser.Email);
                if (outdatedUser != null)// added check so program doesn't terminate
                {
                    db.Entry(outdatedUser).CurrentValues.SetValues(updatedUser);
                    db.SaveChanges();
                }
                else
                {
                    // CreateUser(updatedUser);   TODO: Discuss if create a new user or return.
                    System.Console.WriteLine("User doesn't exist");
                }
            }
        }

        public static void DeleteUserByEmail(string email)
        {
            Contract.Requires(email != null);
            Contract.Requires(GetUserByEmail(email) != null);
            Contract.Ensures(GetUserByEmail(email) == null);

            using (var db = new DatabaseContext())
            {
                try
                {
                    db.Entry(db.Users.Find(email)).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                catch (System.ArgumentNullException e)//Caught when no user exist by the email
                {
                    return;
                }
            }
        }

        public static int UploadFile(DataContracts.FileTransfer transfer)
        {
            Contract.Requires(GetFileInfoById(transfer.Info.Id) == null);
            Contract.Ensures(GetFileInfoById(transfer.Info.Id).Equals(transfer.Info));
            Contract.Ensures(DownloadFileById(transfer.Info.Id).Equals(transfer.Data));

            using (var db = new DatabaseContext())
            {
                var t = transfer;
                var i = t.Info;                

                var newFile = new File
                {
                    Name = i.Name,
                    Data = t.Data,
                    Date = i.Date,
                    Description = i.Description,
                    Origin = i.Origin,
                    Owner = db.Users.Find(i.OwnerEmail),
                    OwnerEmail = i.OwnerEmail,
                    Type = i.Type
                };
                
                db.Files.Add(newFile);                
                db.SaveChanges();

                return newFile.Id;
            }
        }

        [Pure]
        public static byte[] DownloadFileById(int fId)
        {
            Contract.Requires(GetFileInfoById(fId) != null);
            Contract.Ensures(Contract.Result<byte[]>() != null);
            var file = GetFileById(fId);
            return file == null ? null : file.Data;
        }

        [Pure]
        public static DataContracts.FileInfo GetFileInfoById(int fId)
        {
            Contract.Ensures(Contract.Result<DataContracts.FileInfo>() == null
                || Contract.Result<DataContracts.FileInfo>().Id == fId);

            using (var db = new DatabaseContext())
            {
                return (DataContracts.FileInfo)db.Files.Find(fId);
            }
        }

        public static void UpdateFileInfo(DataContracts.FileInfo updatedInfo)
        {
            Contract.Requires(GetFileInfoById(updatedInfo.Id) != null);
            Contract.Ensures(GetFileInfoById(updatedInfo.Id).Equals(updatedInfo));

            using (var db = new DatabaseContext())
            {
                var outdatedFile = db.Files.Find(updatedInfo.Id);
                var updatedFile = (File)updatedInfo;
                updatedFile.Data = outdatedFile.Data;

                db.Entry(outdatedFile).CurrentValues.SetValues(updatedFile);                
                db.SaveChanges();
            }
        }

        public static void UpdateFileData(byte[] updatedData, int fId)
        {
            Contract.Requires(GetFileInfoById(fId) != null);
            Contract.Ensures(DownloadFileById(fId).Equals(updatedData));

            using (var db = new DatabaseContext())
            {
                var outdatedFile = db.Files.Find(fId);
                var updatedFile = (File)((DataContracts.FileInfo)outdatedFile);
                updatedFile.Data = updatedData;

                db.Entry(outdatedFile).CurrentValues.SetValues(updatedFile);
                db.SaveChanges();
            }
        }

        public static void DeleteFileById(int fId)
        {
            Contract.Requires(GetFileInfoById(fId) != null);
            Contract.Ensures(GetFileInfoById(fId) == null);

            using (var db = new DatabaseContext())
            {
                db.Entry(db.Files.Find(fId)).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        [Pure]
        public static HashSet<DataContracts.FileInfo> GetOwnedFileInfosByEmail(string email)
        {
            Contract.Requires(email != null);
            Contract.Requires(GetUserByEmail(email) != null);
            Contract.Ensures(Contract.Result<HashSet<DataContracts.FileInfo>>() != null);
            using (var db = new DatabaseContext())
            {
                var user = db.Users.Find(email);
                var infos = new HashSet<DataContracts.FileInfo>();
                foreach (Item i in user.OwnedItems)
                {
                    var f = i as File;
                    if(f != null)
                        infos.Add((DataContracts.FileInfo)f);
                }
                return infos;
            }
        }

        public static void AddTag(string text, int iId)
        {
            // TODO - Add contracts.

            using (var db = new DatabaseContext())
            {
                if (db.Tags.Find(text, iId) == null)
                {
                    db.Tags.Add(new Tag { Text = text, ItemId = iId, Item = db.Items.Find(iId) });
                    db.SaveChanges();
                }
            }
        }

        public static void DropTag(string text, int iId)
        {
            // TODO - Add contracts.

            using (var db = new DatabaseContext())
            {
                if (db.Tags.Find(text, iId) != null)
                {
                    db.Entry(db.Tags.Find(text,iId)).State = EntityState.Deleted;
                    db.SaveChanges();                              
                }
            }
        }

        [Pure]
        public static List<string> GetTagsByItemId(int iId)
        {
            // TODO - Add contracts.

            using (var db = new DatabaseContext())
            {
                var query = from t in db.Tags where t.ItemId == iId select t.Text;
                return new List<string>(query);
            }
        }

        [Pure]
        public static List<DataContracts.FileInfo> GetFileInfosByTag(string tag)
        {
            // TODO - Add Contracts maybe..? :-S

            using (var db = new DatabaseContext())
            {
                var infos = new List<DataContracts.FileInfo>();

                var query = from t in db.Tags where t.Text.Equals(tag) select t.Item;

                foreach (Item i in query)
                {
                    var f = i as File;
                    if (f != null)
                        infos.Add((DataContracts.FileInfo)f);
                }
                return infos;
            }
        }

        public static int CreatePackage(DataContracts.Package newPackage)
        {
            // TODO - Add contracts.

            using (var db = new DatabaseContext())
            {
                var package = new Package
                {
                    Name = newPackage.Name,
                    Description = newPackage.Description,
                    OwnerEmail = newPackage.OwnerEmail,
                    Owner = db.Users.Find(newPackage.OwnerEmail),
                    Memberships = new List<Membership>()
                };

                db.Packages.Add(package);
                db.SaveChanges();
                foreach (var id in newPackage.FileIds)
                {
                    package.Memberships.Add(new Membership { PackageId = package.Id, FileId = id });
                }
                db.Entry(db.Packages.Find(package.Id)).State = EntityState.Modified;
                db.SaveChanges();
                return package.Id;
            }
        }

        [Pure]
        public static DataContracts.Package GetPackageById(int pId)
        {
            // TODO - Add contracts.

            using (var db = new DatabaseContext())
            {
                return (DataContracts.Package) db.Packages.Find(pId);
            }
        }

        public static void AddToPackage(List<int> fIds, int pId)
        {
            // TODO - Add contracts.

            using (var db = new DatabaseContext())
            {
                var pack = db.Packages.Find(pId);

                foreach (var fId in fIds)
                {
                    var file = db.Files.Find(fId);
                    var ship = new Membership { FileId = file.Id, PackageId = pack.Id };
                    db.Memberships.Add(ship);
                }
                db.SaveChanges();
            }
        }

        public static void RemoveFromPackage(List<int> fIds, int pId)
        {
            // TODO - Add contracts.

            using (var db = new DatabaseContext())
            {
                foreach (var fId in fIds)
                {
                    db.Entry(db.Memberships.Find(pId, fId)).State = EntityState.Deleted;
                }
                db.SaveChanges();
            }
        }

        public static void DeletePackageById(int pId)
        {
            // TODO - Add contracts.

            using (var db = new DatabaseContext())
            {
                db.Entry(db.Packages.Find(pId)).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        [Pure]
        public static HashSet<DataContracts.Package> GetOwnedPackagesByEmail(string email)
        {
            // TODO - Add Contracts.

            using (var db = new DatabaseContext())
            {
                var user = db.Users.Find(email);
                var packages = new HashSet<DataContracts.Package>();                

                foreach (Item i in user.OwnedItems)
                {
                    var p = i as Package;
                    if (p != null)
                        packages.Add((DataContracts.Package)p);
                }
                return packages;
            }
        }

        [Pure]
        public static List<DataContracts.Package> GetPackagesByTag(string tag)
        {
            // TODO - Add Contracts maybe..? :-S

            using (var db = new DatabaseContext())
            {
                var packages = new List<DataContracts.Package>();

                var query = from t in db.Tags where t.Text.Equals(tag) select t.Item;

                foreach (Item i in query)
                {
                    var p = i as Package;
                    if (p != null)
                        packages.Add((DataContracts.Package)p);
                }
                return packages;
            }
        }

        public static void GrantRight(DataContracts.Right newRight)
        {
            // TODO - Add Contracts.

            using (var db = new DatabaseContext())
            {
                var right = (Right) newRight;
                right.Item = db.Items.Find(right.ItemId);
                db.Rights.Add(right);
                db.SaveChanges();
            }
        }

        [Pure]
        public static DataContracts.Right GetRight(int itemId, string email)
        {
            // TODO - Add Contracts.

            using (var db = new DatabaseContext())
            {
                return (DataContracts.Right)db.Rights.Find(email, itemId);
            }
        }

        public static void UpdateRight(DataContracts.Right updatedRight)
        {
            // TODO - Add Contracts.

            using (var db = new DatabaseContext())
            {
                var outdatedRight = db.Rights.Find(updatedRight.UserEmail, updatedRight.ItemId);                
                db.Entry(outdatedRight).CurrentValues.SetValues(updatedRight);
                db.SaveChanges();
            }
        }

        public static void DropRight(string email, int itemId)
        {
            // TODO - Add Contracts.

            using (var db = new DatabaseContext())
            {
                db.Entry(db.Rights.Find(email, itemId)).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        [Pure]
        public static List<DataContracts.FileInfo> SearchFileInfos(string query)
        {
            // TODO - Add Contracts.

            using (var db = new DatabaseContext())
            {
                var linqquery = 
                    from f
                    in db.Files
                    where f.Description.Contains(query)
                    || f.Name.Contains(query)
                    || f.Origin.Contains(query)
                    || f.OwnerEmail.Contains(query)
                    select f;


                var results = new List<DataContracts.FileInfo>();

                foreach (var result in linqquery)
                {
                    results.Add((DataContracts.FileInfo)result);
                }

                return results;
            }
        }

        [Pure]
        public static List<DataContracts.Package> SearchPackages(string query)
        {
            // TODO - Add Contracts.

            using (var db = new DatabaseContext())
            {
                var linqquery = 
                    from p
                    in db.Packages
                    where p.Description.Contains(query)
                    || p.Name.Contains(query)
                    || p.OwnerEmail.Contains(query)
                    select p;

                var results = new List<DataContracts.Package>();

                foreach (var result in linqquery)
                {
                    results.Add((DataContracts.Package)result);
                }

                return results;

            }
        }

        [Pure]
        public static File GetFileById(int fId)
        {
            // TODO - Add Contracts.

            using (var db = new DatabaseContext())
            {
                return db.Files.Find(fId);
            }
        }

        public static Item GetItemById(int itemId) {
            // TODO - Add Contracts.

            using (var db = new DatabaseContext())
            {
                return db.Items.Find(itemId);
            }
        }       
    }
}
