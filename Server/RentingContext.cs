using System.Data.Entity;
using Server.Entities;

namespace Server
{
    public class RentingContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        //public DbSet<Right> Rights { get; set; }

        //public DbSet<Package> Packages { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}