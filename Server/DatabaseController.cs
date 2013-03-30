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

            using (var db = new RentingContext())
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

            using (var db = new RentingContext())
            {
                return (DataContracts.User)db.Users.Find(email);
            }
        }

        public static void UpdateUser(DataContracts.User updatedUser)
        {
            Contract.Requires(updatedUser.Email != null);
            Contract.Requires(GetUserByEmail(updatedUser.Email) != null);
            Contract.Ensures(GetUserByEmail(updatedUser.Email).Equals(updatedUser));

            using (var db = new RentingContext())
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

            using (var db = new RentingContext())
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

            using (var db = new RentingContext())
            {
                var t = transfer;
                var i = t.Info;                
                var tags = i.Tags;

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
                newFile.Tags = new List<Tag>();
                foreach (string s in tags)
                {
                    newFile.Tags.Add(new Tag { Text = s, ItemId = newFile.Id, Item = newFile });
                }
                db.SaveChanges();

                return newFile.Id;
            }
        }

        [Pure]
        public static byte[] DownloadFileById(int fId)
        {
            Contract.Requires(GetFileInfoById(fId) != null);
            Contract.Ensures(Contract.Result<byte[]>() != null);

            using (var db = new RentingContext())
            {
                return db.Files.Find(fId).Data;
            }
        }

        [Pure]
        public static DataContracts.FileInfo GetFileInfoById(int fId)
        {
            Contract.Ensures(Contract.Result<DataContracts.FileInfo>() == null
                || Contract.Result<DataContracts.FileInfo>().Id == fId);

            using (var db = new RentingContext())
            {
                return (DataContracts.FileInfo)db.Files.Find(fId);
            }
        }

        public static void UpdateFileInfo(DataContracts.FileInfo updatedInfo)
        {
            Contract.Requires(GetFileInfoById(updatedInfo.Id) != null);
            Contract.Ensures(GetFileInfoById(updatedInfo.Id).Equals(updatedInfo));

            using (var db = new RentingContext())
            {
                var outdatedFile = db.Files.Find(updatedInfo.Id);
                var updatedFile = (File)updatedInfo;
                updatedFile.Data = outdatedFile.Data;;

                db.Entry(outdatedFile).CurrentValues.SetValues(updatedFile);                
                db.SaveChanges();
            }
        }

        public static void UpdateFileData(byte[] updatedData, int fId)
        {
            Contract.Requires(GetFileInfoById(fId) != null);
            Contract.Ensures(DownloadFileById(fId).Equals(updatedData));

            using (var db = new RentingContext())
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

            using (var db = new RentingContext())
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
            using (var db = new RentingContext())
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

        public static List<DataContracts.FileInfo> GetFileInfosByTag(string tag)
        {
            // TODO - Add Contracts maybe..? :-S

            using (var db = new RentingContext())
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
    }
}
