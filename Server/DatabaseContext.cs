using System.Data.Entity;
using Server.Entities;

namespace Server
{
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Represents the table of User entities.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Represents the table of Item entities.
        /// </summary>
        public DbSet<Item> Items { get; set; }

        /// <summary>
        /// Represents the subset of the table of Item entities that are Files.
        /// </summary>
        public DbSet<File> Files { get; set; }

        /// <summary>
        /// Represents the subset of the table of Item entities that are Packages.
        /// </summary>
        public DbSet<Package> Packages { get; set; }

        /// <summary>
        /// Represents the table of Membership (Package-Item) entities.
        /// </summary>
        public DbSet<Membership> Memberships { get; set; }

        /// <summary>
        /// Represents the table of Right entities.
        /// </summary>
        public DbSet<Tag> Tags { get; set; }

        /// <summary>
        /// Represents the table of Right entities.
        /// </summary>
        public DbSet<Right> Rights { get; set; }
    }
}