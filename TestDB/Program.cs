using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Server;


namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uncomment to reset DB and apply changes.
            Database.SetInitializer(new RentingContextInitializer());
            /*
            using (var db = new RentingContext())
            {
                var query = from u in db.Users
                            orderby u.Email
                            select u;

                Console.WriteLine("All users in the database:");
                foreach (User u in query)
                {
                    Console.WriteLine(u.Email);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
             * */




            File file = new File();

            file.Description= "Et notepad dokument";
            file.Data = System.IO.File.ReadAllBytes("D:\\Dropbox\\BSUP diary\\Todo.txt");
            file.Date = DateTime.Now;
            file.Name = "Todolist";
            file.Origin = "Kewin";

            file.Owner = DatabaseController.getUserByEmail("student@school.com");



            file.Type = FileType.text;
            file.Id = 4;

            DatabaseController.addFile(file);

             




        }
    }    

    public class RentingContextInitializer : DropCreateDatabaseAlways<RentingContext>
    {
        protected override void Seed(RentingContext context)
        {
            // Prepare users.
            var u1 = new User
            {
                Email = "author@books.com",
                Password = "iwritebooks",
                Type = UserType.standard
            };

            var u2 = new User
            {
                Email = "student@school.com",
                Password = "ireadbooks",
                Type = UserType.standard
            };

            var u3 = new User
            {
                Email = "admin@commonknowledge.com",
                Password = "iownthisshit",
                Type = UserType.admin
            };

            var u4 = new User
            {
                Email = "everybody@loves.it",
                Password = "damnrighttheydo",
                Type = UserType.standard
            };

            // Prepare files.
            var f1 = new File
            {
                Name = "Functional Programming using F#",
                Data = new byte[] { 1, 2 },
                Type = FileType.text,
                Description = "This book is awesome!",
                Origin = "Hansel and Rischel",
                Date = DateTime.Now,
                Owner = u1
            };

            var f2 = new File
            {
                Name = "Mudkip",
                Data = new byte[] { 1, 2 },
                Type = FileType.image,
                Description = "I head you like 'em!",
                Origin = "Nintendo",
                Date = DateTime.Now.AddDays(-30),
                Owner = u4
            };

            var f3 = new File
            {
                Name = "Project Management for Information Systems",
                Data = new byte[] { 1, 2 },
                Type = FileType.text,
                Description = "Old people seem to love it...",
                Origin = "Cadle and Yeates",
                Owner = u1
            };

            // Prepare packages.
            var p1 = new Package
            {
                Name = "4th Semester Books",
                Description = "Books from our 4th semester.",
                Files = new List<File> { f1, f3 }
            };

            var p2 = new Package
            {
                Name = "Awesome Stuff",
                Description = "All sorts of awesome stuff.",
                Files = new List<File> { f1, f2 }
            };

            var p3 = new Package
            {
                Name = "Just Mudkip",
                Description = "A single Mudkip image.",
                Files = new List<File> { f2 }
            };

            // Add tags (and thus their tagged files, and those files owners) to the context.
            new List<Tag>
            {
                new Tag { 
                    Text = "awesome", 
                    Files = new List<File> { f1, f2 } },
                new Tag { Text = "software", 
                    Files = new List<File> { f1, f3} },
                new Tag { Text = "boring", 
                    Files = new List<File> { f2 } }
            }.ForEach(t => context.Tags.Add(t));

            // Add rights (and thus their concerning packages and users) to the context.
            new List<Right>
            {
                new Right {
                    Expires = DateTime.Now.AddDays(30),
                    Type = RightsType.manage,
                    User = u1,
                    Package = p1},
                new Right {
                    Type = RightsType.read,
                    User = u2,
                    Package = p1},
                new Right {
                    Type = RightsType.manage,
                    User = u4,
                    Package = p3 },
                new Right {
                    Type = RightsType.manage,
                    User = u3,
                    Package = p2}
            }.ForEach(r => context.Rights.Add(r));

            // Save the changes.
            context.SaveChanges();
        }
    }
}