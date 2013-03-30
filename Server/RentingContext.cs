using System.Data.Entity;
using Server.Entities;

namespace Server
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        //public DbSet<Right> Rights { get; set; }

        public DbSet<Membership> Memberships { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}