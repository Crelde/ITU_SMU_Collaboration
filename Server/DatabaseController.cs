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
                db.Users.Add((User)newUser);
                db.SaveChanges();
            }
        }

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
                db.Entry(outdatedUser).CurrentValues.SetValues(updatedUser);
                db.SaveChanges();
            }
        }

        public static void DeleteUserByEmail(string email)
        {
            Contract.Requires(email != null);
            Contract.Requires(GetUserByEmail(email) != null);
            Contract.Ensures(GetUserByEmail(email) == null);

            using (var db = new DatabaseContext())
            {                
                db.Entry(db.Users.Find(email)).State = EntityState.Deleted;
                db.SaveChanges();                
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

        public static List<string> GetTagsByItemId(int iId)
        {
            // TODO - Add contracts.

            using (var db = new DatabaseContext())
            {
                var query = from t in db.Tags where t.ItemId == iId select t.Text;
                return new List<string>(query);
            }
        }

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
        public static File GetFileById(int fId)
        {
            // TODO - Write Contract.

            using (var db = new DatabaseContext())
            {
                return db.Files.Find(fId);
            }
        }
    }
}
