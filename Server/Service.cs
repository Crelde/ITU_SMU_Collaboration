using Server.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DB = Server.DatabaseController;

namespace Server
{
    public class Service : IService
    {
        // TODO - Test on Server
        public bool CreateUser(User user)
        {
            return DB.CreateUser(user);
        }

        // TODO - Test on Server
        public User ReadUser(string email)
        {
            return DB.GetUserByEmail(email);
        }

        // TODO - Test on Server
        public bool UpdateUser(User user)
        {
            return DB.UpdateUser(user);
        }

        // TODO - Test on Server
        public bool DeleteUser(string email)
        {
            return DB.DeleteUserByEmail(email);
        }

        // TODO - Test
        public bool UploadFile(File file)
        {
            return DB.CreateFile(file);
        }

        // TODO - Test
        public File DownloadFile(int id)
        {
            return DB.GetFileById(id);
        }

        // TODO - Test
        public bool ReplaceFile(File file)
        {
            return DB.ReplaceFile(file);
        }

        // TODO - Test
        public bool RemoveFile(int id)
        {
            return DB.RemoveFileById(id);
        }

        /* TODO - Implement
        public Session LogIn(string email, string password)
        {
            throw new NotImplementedException();
        }
        */

        // TODO - Implement
        public bool LogOut()
        {
            throw new NotImplementedException();
        }

        // TODO - Test
        public bool AddTag(int fileId, string tag)
        {
            return DB.AddTag(fileId, tag);
        }

        // TODO - Test
        public bool RemoveTag(int fileId, string tag)
        {
            return DB.RemoveTag(fileId, tag);
        }

        // TODO - Test
        public List<Package> GetPackagesForUser(string email)
        {
            return DB.GetPackagesByEmail(email);
        }

        // TODO - Implement
        public List<Package> SearchMedia(string query)
        {
            throw new NotImplementedException();
        }

        // TODO - Test
        public bool CreatePackage(Package newPackage)
        {
            return DB.CreatePackage(newPackage);
        }

        // TODO - Test
        public bool DeletePackage(int id)
        {
            return DB.DeletePackageById(id);
        }

        // TODO - Test
        public bool SharePackage(int pId, List<string> emails)
        {
            return DB.SharePackage(pId, emails);            
        }

        // TODO - Test
        public bool AddToPackage(List<int> fIds, int pId)
        {
            return DB.AddToPackage(fIds, pId);
        }

        // TODO - Test
        public bool RemoveFromPackage(List<int> fIds, int pId)
        {
            return DB.RemoveFromPackage(fIds, pId);
        }

        // TODO - Test
        public UserType GetAccountType(string email)
        {
            return DB.getAccountType(email);
        }

        // TODO - Test
        public RightsType GetRightsForFile(int fileId, string email)
        {
            return DB.GetRightsForFile(fileId, email);
        }
    }
}
