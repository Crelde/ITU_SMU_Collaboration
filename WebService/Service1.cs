using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService
{
 
    public class Service1 : IService1
    {

        static void Main(string[] args)
        {
            Console.WriteLine("sup");
            Console.ReadKey();
        }

        bool IService1.CreateUser(Contrib.User user)
        {
            throw new NotImplementedException();
        }

        Contrib.User IService1.ReadUser(string email)
        {
            throw new NotImplementedException();
        }

        bool IService1.UpdateUser(Contrib.User user)
        {
            throw new NotImplementedException();
        }

        bool IService1.DeleteUser(string email)
        {
            throw new NotImplementedException();
        }

        bool IService1.UploadFile(Contrib.File file)
        {
            throw new NotImplementedException();
        }

        Contrib.File IService1.DownloadFile(int id)
        {
            throw new NotImplementedException();
        }

        bool IService1.ReplaceFile(Contrib.File file)
        {
            throw new NotImplementedException();
        }

        bool IService1.RemoveFile(int id)
        {
            throw new NotImplementedException();
        }

        Contrib.Session IService1.LogIn(string email, string password)
        {
            throw new NotImplementedException();
        }

        bool IService1.LogOut()
        {
            throw new NotImplementedException();
        }

        bool IService1.AddTag(int fileId, string tag)
        {
            throw new NotImplementedException();
        }

        bool IService1.RemoveTag(int fileId, string tag)
        {
            throw new NotImplementedException();
        }

        List<Contrib.Package> IService1.GetPackagesForUser(string email)
        {
            throw new NotImplementedException();
        }

        List<Contrib.Package> IService1.SearchMedia(string query)
        {
            throw new NotImplementedException();
        }

        bool IService1.CreatePackage(Contrib.Package p)
        {
            throw new NotImplementedException();
        }

        bool IService1.DeletePackage(int pId)
        {
            throw new NotImplementedException();
        }

        bool IService1.SharePackage(int pId, List<string> emails)
        {
            throw new NotImplementedException();
        }

        bool IService1.AddToPackage(List<int> fIds, int pId)
        {
            throw new NotImplementedException();
        }

        bool IService1.RemoveFromPackage(List<int> fIds, int pId)
        {
            throw new NotImplementedException();
        }
    }
}
