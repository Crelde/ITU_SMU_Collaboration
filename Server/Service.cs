using Server.DataContracts;
using System.Collections.Generic;
using DB = Server.DatabaseController;

namespace Server
{
    public class Service : IService
    {
        /// <summary>
        /// Create a new User on the service.
        /// </summary>
        /// 
        /// <param name="newUser">
        /// The User object that should be created on the service.
        /// </param>
        public void CreateUser(User newUser)
        {
            DB.CreateUser(newUser);
        }

        /// <summary>
        /// Look up a User by its email address.
        /// </summary>
        /// 
        /// <param name="email">
        /// The email of the User to be returned.
        /// </param>
        /// 
        /// <returns>
        /// The User whose Email property matches the given email.
        /// </returns>
        public User GetUserByEmail(string email)
        {
            return DB.GetUserByEmail(email);
        }

        /// <summary>
        /// Updates the details of an existing User whose Email 
        /// property matches the Email property of the one given.
        /// </summary>
        /// 
        /// <param name="updatedUser">
        /// The User object which contains the updated details.
        /// </param>
        public void UpdateUser(User updatedUser)
        {
            DB.UpdateUser(updatedUser);
        }

        /// <summary>
        /// Deletes the User whose Email property matches the given email.
        /// </summary>
        /// 
        /// <param name="email">
        /// The email address of the User which should be deleted.
        /// </param>
        public void DeleteUserByEmail(string email)
        {
            DB.DeleteUserByEmail(email);
        }

        /// <summary>
        /// Uploads the binary data and FileInfo contained within the given transfer object.
        /// </summary>
        /// 
        /// <param name="transfer">
        /// The object containing the info and data of the file which should be uploaded.
        /// </param>
        /// 
        /// <returns>
        /// 
        /// </returns>
        public int UploadFile(FileTransfer transfer)
        {
            return DB.UploadFile(transfer);
        }

        /// <summary>
        /// Downloads the binary data of the file whose Id property
        /// matches the given fileId.
        /// </summary>
        /// 
        /// <param name="fileId">
        /// The Id of the file whose data should be downloaded.
        /// </param>
        /// 
        /// <returns>
        /// The binary data of the matching file.
        /// </returns>
        public byte[] DownloadFileById(int fileId)
        {
            return DB.DownloadFileById(fileId);
        }

        /// <summary>
        /// Looks up the info of a file by its Id.
        /// </summary>
        /// 
        /// <param name="fileId">
        /// The Id of the file whose info should be returned.
        /// </param>
        /// 
        /// <returns>
        /// The FileInfo of the file whose Id property matched the given fileId.
        /// </returns>
        public FileInfo GetFileInfoById(int fileId)
        {
            return DB.GetFileInfoById(fileId);
        }

        /// <summary>
        ///  Updates the file that matches updatedInfo's Id with the details contained within it.
        /// </summary>
        /// 
        /// <param name="updatedInfo">
        /// The FileInfo object that contains the new info.
        /// </param>
        public void UpdateFileInfo(FileInfo updatedInfo)
        {
            DB.UpdateFileInfo(updatedInfo);
        }

        /// <summary>
        /// Updates the File with the matching fileId with the givne updatedData.
        /// </summary>
        /// 
        /// <param name="updatedData">
        /// The updated data.
        /// </param>
        /// 
        /// <param name="fileId">
        /// The Id of the file which data should be updated.
        /// </param>
        public void UpdateFileData(byte[] updatedData, int fileId)
        {
            DB.UpdateFileData(updatedData, fileId);
        }

        /// <summary>
        /// Deletes the File with the matching fileId.
        /// </summary>
        /// <param name="fileId">The Id of the file which should be deleted.</param>
        public void DeleteFileById(int fileId)
        {
            DB.DeleteFileById(fileId);
        }

        /// <summary>
        /// Returns the FileInfos of the Files owned by the User with the given email.
        /// </summary>
        /// 
        /// <param name="email">
        /// The email of the User in question.
        /// </param>
        /// 
        /// <returns>
        /// The FileInfos of the files owned by the User.
        /// </returns>
        public HashSet<FileInfo> GetOwnedFileInfosByEmail(string email)
        {
            return DB.GetOwnedFileInfosByEmail(email);
        }

        /// <summary>
        /// Adds the given tag to the Item with the given Id.
        /// </summary>
        /// 
        /// <param name="tag">
        /// The tag text.
        /// </param>
        /// 
        /// <param name="itemId">
        /// The Id of the Item which should be tagged.
        /// </param>
        public void AddTag(string tag, int itemId)
        {
            DB.AddTag(tag, itemId);
        }

        /// <summary>
        /// Removes the given tag from the Item with the given Id.
        /// </summary>
        /// 
        /// <param name="tag">
        /// The tag text.
        /// </param>
        /// 
        /// <param name="itemId">
        /// The Id of the Item which should be untagged.
        /// </param>
        public void DropTag(string tag, int itemId)
        {
            DB.DropTag(tag, itemId);
        }

        /// <summary>
        /// Returns the tags that the Item with the given Id has.
        /// </summary>
        /// 
        /// <param name="itemId">
        /// The Id of the Item whose tags should be returned.
        /// </param>
        /// 
        /// <returns>
        /// The tags of the matching Item.
        /// </returns>
        public List<string> GetTagsByItemId(int itemId)
        {
            return DB.GetTagsByItemId(itemId);
        }

        /// <summary>
        /// Looks up FileInfos with a matching tag.
        /// </summary>
        /// 
        /// <param name="tag">
        /// The tag that should be used to look up FileInfos.
        /// </param>
        /// 
        /// <returns>
        /// The FileInfos that contain the given tag.
        /// </returns>
        public List<FileInfo> GetFileInfosByTag(string tag)
        {
            return DB.GetFileInfosByTag(tag);
        }

        /// <summary>
        /// Creates the given Package on the service.
        /// </summary>
        /// 
        /// <param name="newPackage">
        /// The Package that should be created.
        /// </param>
        /// 
        /// <returns>
        /// The Id that the created Package has been given.
        /// </returns>
        public int CreatePackage(Package newPackage)
        {
            return DB.CreatePackage(newPackage);
        }

        /// <summary>
        /// Look up a Package by its Id.
        /// </summary>
        /// 
        /// <param name="packageId">
        /// The Id of the Package that should be returned.
        /// </param>
        /// 
        /// <returns>
        /// The Package with the matching packageId.
        /// </returns>
        public Package GetPackageById(int packageId)
        {
            return DB.GetPackageById(packageId);
        }

        /// <summary>
        /// Adds some Files to a Package.
        /// </summary>
        /// 
        /// <param name="fileIds">
        /// The Ids of the Files that should be added to the Pacakge.
        /// </param>
        /// 
        /// <param name="packageId">
        /// The Id of the Package to which the Files should be added.
        /// </param>
        public void AddToPackage(List<int> fileIds, int packageId)
        {
            DB.AddToPackage(fileIds, packageId);
        }

        /// <summary>
        /// Removes some Files from a Package.
        /// </summary>
        /// 
        /// <param name="fileIds">
        /// The Ids of the Files that should be removed from the Package.
        /// </param>
        /// 
        /// <param name="packageId">
        /// The Id of the Package from which the Files should be removed.
        /// </param>
        public void RemoveFromPackage(List<int> fileIds, int packageId)
        {
            DB.RemoveFromPackage(fileIds, packageId);
        }

        /// <summary>
        /// Deletes a Package by its Id.
        /// </summary>
        /// 
        /// <param name="packageId">
        /// The Id of the Package which should be deleted.
        /// </param>
        public void DeletePackageById(int packageId)
        {
            DB.DeletePackageById(packageId);
        }

        /// <summary>
        /// Returns the Packages owned by the User with the given email.
        /// </summary>
        /// 
        /// <param name="email">
        /// The email of the User in question.
        /// </param>
        /// 
        /// <returns>
        /// The Packages owned by the User.
        /// </returns>
        public HashSet<Package> GetOwnedPackagesByEmail(string email)
        {
            return DB.GetOwnedPackagesByEmail(email);
        }

        /// <summary>
        /// Looks up Packages with a matching tag.
        /// </summary>
        /// 
        /// <param name="tag">
        /// The tag that should be used to look up Packages.
        /// </param>
        /// 
        /// <returns>
        /// The Packages that contain the given tag.
        /// </returns>
        public List<Package> GetPackagesByTag(string tag)
        {
            return DB.GetPackagesByTag(tag);
        }        

        /// <summary>
        /// Adds the given Right to the service.
        /// </summary>
        /// 
        /// <param name="newRight">
        /// The Right that should be created on the service.
        /// </param>
        public void GrantRight(Right newRight)
        {
            DB.GrantRight(newRight);
        }

        /// <summary>
        /// Looks up a Right by the email of the User and the Id of the Item involved.
        /// </summary>
        /// 
        /// <param name="email">
        /// The Email of the User whom the Right concerns.
        /// </param>
        /// 
        /// <param name="itemId">
        /// The Id of the Item which the Right concerns.
        /// </param>
        /// 
        /// <returns>
        /// The Right with the matching email and itemId.
        /// </returns>
        public Right GetRight(string email, int itemId)
        {
            return DB.GetRight(itemId, email);
        }

        /// <summary>
        /// Updates the exising right that has matching UserEmail and ItemId fields, 
        /// with the rest of the fields from the given updatedRight.
        /// </summary>
        /// 
        /// <param name="updatedRight">
        /// The updated Right object.
        /// </param>
        public void UpdateRight(Right updatedRight)
        {
            DB.UpdateRight(updatedRight);
        }

        /// <summary>
        /// Removes the right associated with the User with the given email address, 
        /// and the Item with the given Id.
        /// </summary>
        /// 
        /// <param name="email">
        /// The Email of the User whom the Right concerns.
        /// </param>
        /// 
        /// <param name="itemId">
        /// The Id of the Item which the Right concerns.
        /// </param>
        public void DropRight(string email, int itemId)
        {
            DB.DropRight(email, itemId);
        }

        /// <summary>
        /// Looks up Files by matching their details with a string of text.
        /// </summary>
        /// 
        /// <param name="text">
        /// The text which should be contained in the Files.
        /// </param>
        /// 
        /// <returns>
        /// The Files that contain the given text somewhere in their details.
        /// </returns>
        public List<FileInfo> SearchFileInfos(string text)
        {
            return DB.SearchFileInfos(text);
        }

        /// <summary>
        /// Looks up Packages by matching their details with a string of text.
        /// </summary>
        /// 
        /// <param name="text">
        /// The text which should be contained in the Files.
        /// </param>
        /// 
        /// <returns>
        /// The Packages that contain the given text somewhere in their details.
        /// </returns>
        public List<Package> SearchPackages(string text)
        {
            return DB.SearchPackages(text);
        }
    }
}
