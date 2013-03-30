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

        public List<FileInfo> GetFileInfosByTag(string tag)
        {
            return DB.GetFileInfosByTag(tag);
        }





        public HashSet<Package> GetPackagesByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public List<Package> GetPackagesByTag(string tag)
        {
            throw new System.NotImplementedException();
        }

        public void CreatePackage(Package p)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePackageById(int pId)
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

        public bool AddToPackage(List<int> fIds, int pId)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveFromPackage(List<int> fIds, int pId)
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
