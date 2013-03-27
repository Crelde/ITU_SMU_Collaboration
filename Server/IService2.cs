using Server.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace Server
{
    [ServiceContract]
    public interface IService2
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
        HashSet<FileInfo> GetFileInfosByEmail(string email);

        [OperationContract]
        HashSet<Package> GetPackagesByEmail(string email);

        [OperationContract]
        HashSet<Right> GetRights(int? itemId = null, string email = null);

        [OperationContract]
        byte[] DownloadFileById(int id);

        [OperationContract]
        FileInfo GetFileInfoById(int id);

        [OperationContract]
        void UploadFile(FileTransfer transfer);

        // NOTE - What if we only want to change the info?
        [OperationContract]
        void UpdateFile(FileTransfer transfer);

        [OperationContract]
        void DeleteFileById(int id);

        [OperationContract]
        List<string> GetTagsByItemId(int itemId);

        [OperationContract]
        List<FileInfo> GetFileInfosByTag(string tag);

        [OperationContract]
        List<Package> GetPacakgesByTag(string tag);
    }
}
