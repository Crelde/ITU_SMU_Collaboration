using Server.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace Server
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void CreateUser(User newUser);

        [OperationContract]
        User GetUserByEmail(string email);

        [OperationContract]
        void UpdateUser(User updatedUser);

        [OperationContract]
        void DeleteUserByEmail(string email);

        [OperationContract]
        int UploadFile(FileTransfer transfer);

        [OperationContract]
        byte[] DownloadFileById(int fileId);

        [OperationContract]
        FileInfo GetFileInfoById(int fileId);

        [OperationContract]
        void UpdateFileInfo(FileInfo updatedInfo);

        [OperationContract]
        void UpdateFileData(byte[] updatedData, int fileId);

        [OperationContract]
        void DeleteFileById(int fileId);

        [OperationContract]
        HashSet<FileInfo> GetOwnedFileInfosByEmail(string email);

        [OperationContract]
        void AddTag(string tag, int itemId);

        [OperationContract]
        void DropTag(string tag, int itemId);

        [OperationContract]
        List<string> GetTagsByItemId(int ïtemId);

        [OperationContract]
        List<FileInfo> GetFileInfosByTag(string tag);

        [OperationContract]
        int CreatePackage(Package newPackage);

        [OperationContract]
        Package GetPackageById(int packageId);

        [OperationContract]
        void AddToPackage(List<int> fileIds, int packageId);

        [OperationContract]
        void RemoveFromPackage(List<int> fileIds, int packageId);

        [OperationContract]
        void DeletePackageById(int packageId);

        [OperationContract]
        HashSet<Package> GetOwnedPackagesByEmail(string email);

        [OperationContract]
        List<Package> GetPackagesByTag(string tag);

        [OperationContract]
        void GrantRight(Right newRight);

        [OperationContract]
        Right GetRight(string email, int itemId);

        [OperationContract]
        void UpdateRight(Right updatedRight);

        [OperationContract]
        void DropRight(string email, int itemId);

        [OperationContract]
        List<FileInfo> SearchFileInfos(string text);

        [OperationContract]
        List<Package> SearchPackages(string text);
    }
}
