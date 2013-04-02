using Server.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace Server
{
    [ServiceContract(
        SessionMode = SessionMode.Required
    )]
    public interface IService
    {
        [OperationContract(IsInitiating = true)]
        void LogIn(string user, string password);

        [OperationContract(IsInitiating = false, IsTerminating = true)]
        void LogOut();
        
        // TODO - maybe this one should be session-initiating as well?
        [OperationContract(IsInitiating = false)]
        void CreateUser(User newUser);

        [OperationContract(IsInitiating = false)]
        User GetUserByEmail(string email);

        [OperationContract(IsInitiating = false)]
        void UpdateUser(User updatedUser);

        [OperationContract(IsInitiating = false)]
        void DeleteUserByEmail(string email);

        [OperationContract(IsInitiating = false)]
        int UploadFile(FileTransfer transfer);

        [OperationContract(IsInitiating = false)]
        byte[] DownloadFileById(int fileId);

        [OperationContract(IsInitiating = false)]
        FileInfo GetFileInfoById(int fileId);

        [OperationContract(IsInitiating = false)]
        void UpdateFileInfo(FileInfo updatedInfo);

        [OperationContract(IsInitiating = false)]
        void UpdateFileData(byte[] updatedData, int fileId);

        [OperationContract(IsInitiating = false)]
        void DeleteFileById(int fileId);

        [OperationContract(IsInitiating = false)]
        HashSet<FileInfo> GetOwnedFileInfosByEmail(string email);

        [OperationContract(IsInitiating = false)]
        void AddTag(string tag, int itemId);

        [OperationContract(IsInitiating = false)]
        void DropTag(string tag, int itemId);

        [OperationContract(IsInitiating = false)]
        List<string> GetTagsByItemId(int ïtemId);

        [OperationContract(IsInitiating = false)]
        List<FileInfo> GetFileInfosByTag(string tag);

        [OperationContract(IsInitiating = false)]
        int CreatePackage(Package newPackage);

        [OperationContract(IsInitiating = false)]
        Package GetPackageById(int packageId);

        [OperationContract(IsInitiating = false)]
        void AddToPackage(List<int> fileIds, int packageId);

        [OperationContract(IsInitiating = false)]
        void RemoveFromPackage(List<int> fileIds, int packageId);

        [OperationContract(IsInitiating = false)]
        void DeletePackageById(int packageId);

        [OperationContract(IsInitiating = false)]
        HashSet<Package> GetOwnedPackagesByEmail(string email);

        [OperationContract(IsInitiating = false)]
        List<Package> GetPackagesByTag(string tag);

        [OperationContract(IsInitiating = false)]
        void GrantRight(Right newRight);

        [OperationContract(IsInitiating = false)]
        Right GetRight(string email, int itemId);

        [OperationContract(IsInitiating = false)]
        void UpdateRight(Right updatedRight);

        [OperationContract(IsInitiating = false)]
        void DropRight(string email, int itemId);

        [OperationContract(IsInitiating = false)]
        List<FileInfo> SearchFileInfos(string text);

        [OperationContract(IsInitiating = false)]
        List<Package> SearchPackages(string text);
    }
}
