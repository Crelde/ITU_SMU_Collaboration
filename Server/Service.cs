using Server.DataContracts;
using System.Collections.Generic;
using DB = Server.DatabaseController;

namespace Server
{
    public class Service : IService
    {

        public void CreateUser(User newUser)
        {
            DB.CreateUser(newUser);
        }

        public User GetUserByEmail(string email)
        {
            return DB.GetUserByEmail(email);
        }

        public void UpdateUser(User updatedUser)
        {
            DB.UpdateUser(updatedUser);
        }

        public void DeleteUserByEmail(string email)
        {
            DB.DeleteUserByEmail(email);
        }

        public int UploadFile(FileTransfer transfer)
        {
            return DB.UploadFile(transfer);
        }

        public byte[] DownloadFileById(int fileId)
        {
            return DB.DownloadFileById(fileId);
        }

        public FileInfo GetFileInfoById(int fileId)
        {
            return DB.GetFileInfoById(fileId);
        }

        public void UpdateFileInfo(FileInfo updatedInfo)
        {
            DB.UpdateFileInfo(updatedInfo);
        }

        public void UpdateFileData(byte[] updatedData, int fileId)
        {
            DB.UpdateFileData(updatedData, fileId);
        }

        public void DeleteFileById(int fileId)
        {
            DB.DeleteFileById(fileId);
        }

        public HashSet<FileInfo> GetOwnedFileInfosByEmail(string email)
        {
            return DB.GetOwnedFileInfosByEmail(email);
        }

        public void AddTag(string tag, int itemId)
        {
            DB.AddTag(tag, itemId);
        }

        public void DropTag(string tag, int itemId)
        {
            DB.DropTag(tag, itemId);
        }

        public List<string> GetTagsByItemId(int itemId)
        {
            return DB.GetTagsByItemId(itemId);
        }

        public List<FileInfo> GetFileInfosByTag(string tag)
        {
            return DB.GetFileInfosByTag(tag);
        }

        public int CreatePackage(Package newPackage)
        {
            return DB.CreatePackage(newPackage);
        }

        public Package GetPackageById(int packageId)
        {
            return DB.GetPackageById(packageId);
        }

        public void AddToPackage(List<int> fileIds, int packageId)
        {
            DB.AddToPackage(fileIds, packageId);
        }

        public void RemoveFromPackage(List<int> fileIds, int packageId)
        {
            DB.RemoveFromPackage(fileIds, packageId);
        }

        public void DeletePackageById(int packageId)
        {
            DB.DeletePackageById(packageId);
        }

        public HashSet<Package> GetOwnedPackagesByEmail(string email)
        {
            return DB.GetOwnedPackagesByEmail(email);
        }

        public List<Package> GetPackagesByTag(string tag)
        {
            return DB.GetPackagesByTag(tag);
        }        

        public void GrantRight(Right newRight)
        {
            DB.GrantRight(newRight);
        }

        public Right GetRight(string email, int itemId)
        {
            return DB.GetRight(itemId, email);
        }

        public void UpdateRight(Right updatedRight)
        {
            DB.UpdateRight(updatedRight);
        }

        public void DropRight(string email, int itemId)
        {
            DB.DropRight(email, itemId);
        }

        public List<FileInfo> SearchFileInfos(string query)
        {
            throw new System.NotImplementedException();
        }

        public List<Package> SearchPackages(string query)
        {
            throw new System.NotImplementedException();
        }
    }
}
