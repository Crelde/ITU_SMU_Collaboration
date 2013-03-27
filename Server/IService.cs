using Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    /*
     * NOTE - Most of the booleans are to indicate the success or failure of executing the given method.
     * TODO - Consider using a different format for reporting the success of an operation.
     */
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        bool CreateUser(User user);

        [OperationContract]
        User ReadUser(string email);

        [OperationContract]
        bool UpdateUser(User user);

        [OperationContract]
        bool DeleteUser(string email);

        [OperationContract]
        bool UploadFile(File file);

        [OperationContract]
        File DownloadFile(int id);

        /*
         * NOTE - Should this specify which file to replace the file with, or should that job also go the single argument?
         * 
         * NOTE - As I see it, we have two options:
         *      1 Change it to ReplaceFile(int fileId, File file)
         *        Which replaces the file with the given id with the new file.
         *      2 Keep it as it is. Use the given files id to match an existing files id, and overwrite that file.
         *      
         *        In both cases, an exception should be thrown if no matching file was found, since it indicates and error
         *        at either the client or server side. I'd suggest it does NOT just interpret it as a call to UploadFile!
         * 
         */
        [OperationContract]
        bool ReplaceFile(File file);

        [OperationContract]
        bool RemoveFile(int id);

        /* Uncomment when we know what the fuck we are doing...
        [OperationContract]
        Session LogIn(string email, string password);
        */
        [OperationContract]
        UserType GetAccountType(string email);

        [OperationContract]
        RightsType GetRightsForFile(int fileId, string email);

        [OperationContract]
        bool LogOut();

        // NOTE - Maybe we should make a Tag class instead?
        // NOTE - That depends, do we need features that a string doesn't provide?
        [OperationContract]
        bool AddTag(int fileId, string tag);

        [OperationContract]
        bool RemoveTag(int fileId, string tag);

        [OperationContract]
        List<Package> GetPackagesForUser(string email);

        // NOTE - Depending on how we want to do this we can return packages or files here its package.
        // NOTE - I think we agreed on putting files in packages also. I might be wrong... :-/
        [OperationContract]
        List<Package> SearchMedia(string query);

        [OperationContract]
        bool CreatePackage(Package p);

        [OperationContract]
        bool DeletePackage(int pId);

        [OperationContract]
        bool SharePackage(int pId, List<string> emails);

        [OperationContract]
        bool AddToPackage(List<int> fIds, int pId);

        [OperationContract]
        bool RemoveFromPackage(List<int> fIds, int pId);
    }
}
