using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService
{
    //The many bools is supposed to tell if the method went good or bad, seems excessive to have it on every method, to be discussed.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool CreateUser(Contrib.User user);

        [OperationContract]
        Contrib.User ReadUser(string email);

        [OperationContract]
        bool UpdateUser(Contrib.User user);

        [OperationContract]
        bool DeleteUser(string email);

        [OperationContract]
        bool UploadFile(Contrib.File file);

        [OperationContract]
        Contrib.File DownloadFile(int id);

        // Should this specify which file to replace the file with? or should that job also go the single argument?
        [OperationContract]
        bool ReplaceFile(Contrib.File file);

        [OperationContract]
        bool RemoveFile(int id);

        [OperationContract]
        Contrib.Session LogIn(string email, string password);

        [OperationContract]
        Contrib.User.UserType GetAccountType(string email);

        [OperationContract]
        bool GetRightsForFile(int fileId, string email);

        // pussy out!
        [OperationContract]
        bool LogOut();

        // we could also make a tag class instead of just parsing a string
        [OperationContract]
        bool AddTag(int fileId, string tag);

        [OperationContract]
        bool RemoveTag(int fileId, string tag);

        [OperationContract]
        List<Contrib.Package> GetPackagesForUser(string email);

        // Depending on how we want to do this we can return packages or files here its package
        [OperationContract]
        List<Contrib.Package> SearchMedia(string query);

        [OperationContract]
        bool CreatePackage(Contrib.Package p);

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
