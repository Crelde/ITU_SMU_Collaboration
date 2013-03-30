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

        public byte[] DownloadFileById(int fId)
        {
            return DB.DownloadFileById(fId);
        }

        public FileInfo GetFileInfoById(int fId)
        {
            return DB.GetFileInfoById(fId);
        }

        public void UpdateFileInfo(FileInfo updatedInfo)
        {
            DB.UpdateFileInfo(updatedInfo);
        }

        public void UpdateFileData(byte[] updatedData, int fId)
        {
            DB.UpdateFileData(updatedData, fId);
        }

        public void DeleteFileById(int fId)
        {
            DB.DeleteFileById(fId);
        }

        public HashSet<FileInfo> GetOwnedFileInfosByEmail(string email)
        {
            return DB.GetOwnedFileInfosByEmail(email);
        }

        public void AddTag(string text, int iId)
        {
            DB.AddTag(text, iId);
        }

        public void DropTag(string text, int iId)
        {
            DB.DropTag(text, iId);
        }

        public List<string> GetTagsByItemId(int iId)
        {
            return DB.GetTagsByItemId(iId);
        }

        public List<FileInfo> GetFileInfosByTag(string tag)
        {
            return DB.GetFileInfosByTag(tag);
        }

        public int CreatePackage(Package newPackage)
        {
            return DB.CreatePackage(newPackage);
        }

        public Package GetPackageById(int pId)
        {
            return DB.GetPackageById(pId);
        }

        public void AddToPackage(List<int> fIds, int pId)
        {
            DB.AddToPackage(fIds, pId);
        }

        public void RemoveFromPackage(List<int> fIds, int pId)
        {
            DB.RemoveFromPackage(fIds, pId);
        }

        public void DeletePackageById(int pId)
        {
            DB.DeletePackageById(pId);
        }







        public HashSet<Package> GetOwnedPackagesByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public List<Package> GetPackagesByTag(string tag)
        {
            throw new System.NotImplementedException();
        }

        public void GrantRights(int iId, List<string> emails, RightType Type)
        {
            throw new System.NotImplementedException();
        }

        public HashSet<Right> GetRights(int? itemId = null, string email = null)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateRights(int iId, List<string> emails, RightType Type)
        {
            throw new System.NotImplementedException();
        }

        public void DropRights(int iId, List<string> emails)
        {
            throw new System.NotImplementedException();
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
