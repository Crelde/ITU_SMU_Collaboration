using Server.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace Server
{
    [ServiceContract]
    public interface IService
    {
        /*
         * Creates a new User, using the newUser object.
         */
        [OperationContract]
        void CreateUser(User newUser);

        /*
         * Returns the User with the given email.
         */
        [OperationContract]
        User GetUserByEmail(string email);

        /*
         * Finds the User having the same Email as updatedUser and replaces the rest
         * of its details with the ones in updatedUser.
         */
        [OperationContract]
        void UpdateUser(User updatedUser);

        /*
         * Deletes the User with the given email.
         */
        [OperationContract]
        void DeleteUserByEmail(string email);

        /*
         * Uploads the binary data and FileInfo contained in the transfer object.
         * Returns the Id that the newly created File has been granted.
         */
        [OperationContract]
        int UploadFile(FileTransfer transfer);

        /*
         * Downloads the binary data of the File with the given fId.
         */
        [OperationContract]
        byte[] DownloadFileById(int fId);

        /*
         * Returns the FileInfo of the File with the given fId.
         */
        [OperationContract]
        FileInfo GetFileInfoById(int fId);

        /*
         * Updates the File that matches updatedInfo's Id
         * with the details contained within.
         */
        [OperationContract]
        void UpdateFileInfo(FileInfo updatedInfo);

        /*
         * Updates the File with mathcing fId with the givne updatedData.
         */
        [OperationContract]
        void UpdateFileData(byte[] updatedData, int fId);

        /*
         * Deletes the File with the matching fId.
         */
        [OperationContract]
        void DeleteFileById(int fId);

        /*
         * Returns the FileInfos of the Files owned by the User with the given email.
         */
        [OperationContract]
        HashSet<FileInfo> GetOwnedFileInfosByEmail(string email);

        /*
         * Returns the FileInfos that contain the given tag.
         */
        [OperationContract]
        List<FileInfo> GetFileInfosByTag(string tag);






        /*
         * Returns the Packages owned by the User with the given email.
         * NOTE - Should it just be Owned, or also Packages with View/Edit rights?
         */
        [OperationContract]
        HashSet<Package> GetPackagesByEmail(string email);

        /*
         * Returns the Packages that contain the given tag.
         */
        [OperationContract]
        List<Package> GetPackagesByTag(string tag);

        /*
         * Creates the given Package on the service.
         */
        [OperationContract]
        void CreatePackage(Package p);

        /*
         * Deletes the Package with the matching pId.
         */
        [OperationContract]
        void DeletePackageById(int pId);

        /*
         * Grants the Users with matching emails the Rights specified by the Type enum to the 
         * Item with the given iId.
         */
        [OperationContract]
        void GrantRights(int iId, List<string> emails, RightType Type);

        /*
         * Returns the Rights matching the given details.
         * NOTE - Discuss how it should handle different inputs.
         */
        [OperationContract]
        HashSet<Right> GetRights(int? itemId = null, string email = null);

        /*
         * Updates Rights that the Users with matching emails have to the
         * Item with the given iId.
         */
        [OperationContract]
        void UpdateRights(int iId, List<string> emails, RightType Type);

        /*
         * Removes the Rights that the Users with matching emails have to the
         * Item with the given iId.
         */
        [OperationContract]
        void DropRights(int iId, List<string> emails);

        /*
         * Adds the Files with matching pIds to the Package with the macthing pId.
         */
        [OperationContract]
        bool AddToPackage(List<int> fIds, int pId);

        /*
         * Removes the Files with matching pIds from the Package with the macthing pId.
         */
        [OperationContract]
        bool RemoveFromPackage(List<int> fIds, int pId);

        /*
         * Returns a List of FileInfos that match the given search query in some fashion.
         */
        [OperationContract]
        List<FileInfo> SearchFileInfos(string query);

        /*
         * Returns a List of Packages that match the given search query in some fashion.
         */
        [OperationContract]
        List<Package> SearchPackages(string query);
    }
}
