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


        public bool CreateUser(User user)
        {
            return DB.addUser(user);
        }

        public User ReadUser(string email)
        {
            return DB.getUserByEmail(email);
        }

        public bool UpdateUser(User user)
        {
            return DB.updateUser(user);
        }

        public bool DeleteUser(string email)
        {
            return DB.deleteUserByEmail(email);
        }

        public bool UploadFile(File file)
        {
            throw new NotImplementedException();
        }

        public File DownloadFile(int id)
        {
            throw new NotImplementedException();
        }

        public bool ReplaceFile(File file)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFile(int id)
        {
            throw new NotImplementedException();
        }
        /*
        public Session LogIn(string email, string password)
        {
            throw new NotImplementedException();
        }
        */
        public bool LogOut()
        {
            throw new NotImplementedException();
        }

        public bool AddTag(int fileId, string tag)
        {
            // NOTE - Eh not sure where we get the File object from the fileId from, to be discussed, temporary solution:
            // File f = GetFileById(fileId);??
            // NOTE - I think we'll get it by querying the underlying DB. :-)

            File f = new File();

            // NOTE - The AddTag method in file check if it already exists and adds it if it doesn't.
            // NOTE - Changed the file to use a HashSet instead. Much more appropriate. ;-)
            //f.AddTag(tag);

            // NOTE - Method not fully implemented yet.
            throw new NotImplementedException();
        }

        public bool RemoveTag(int fileId, string tag)
        {
            // TODO - Retrieve actual file from DB.
            // Make changes to file and commit to DB.
            File f = new File();
            //f.RemoveTag(tag);

            // NOTE - Method not fully implemented yet.
            throw new NotImplementedException();
        }

        public List<Package> GetPackagesForUser(string email)
        {
            throw new NotImplementedException();
        }

        public List<Package> SearchMedia(string query)
        {
            throw new NotImplementedException();
        }

        public bool CreatePackage(Package p)
        {
            throw new NotImplementedException();
        }

        public bool DeletePackage(int pId)
        {
            throw new NotImplementedException();
        }

        public bool SharePackage(int pId, List<string> emails)
        {
            // NOTE - How do we get the package by id?
            // Package p = GetPackageById(pId);??
            // NOTE - By querying the DB i guess... :-/

            Package p = new Package();
            foreach (string e in emails)
            {
                //  We need a method like this i think. - Crelde
                // User u = User.GetUserByEmail(e);
                // p.addUser(u);
            }

            // Method is still not done...
            throw new NotImplementedException();
        }

        public bool AddToPackage(List<int> fIds, int pId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFromPackage(List<int> fIds, int pId)
        {
            throw new NotImplementedException();
        }

        public UserType GetAccountType(string email)
        {
            return DB.getAccountType(email);
        }

        public bool GetRightsForFile(int fileId, string email)
        {
            throw new NotImplementedException();
        }
    }

    /*
     * NOTE - 
     *  It seems a lot of the questions are about retrieving data.
     *  Many of the solutions seem to be queries to the DB.
     *  Maybe we should make a class for DB interaction that exposes
     *  the required data retrieval features as methods? :-)
     */
}
