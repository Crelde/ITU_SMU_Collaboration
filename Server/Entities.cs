using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Server
{
    public class RentingContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Right> Rights { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }

    public enum UserType
    {
        standard,
        admin
    };

    public class User
    {
        [Key, Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public UserType Type { get; set; }
    }

    public enum RightsType
    {
        read,
        manage
    };

    public class Right
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserEmail { get; set; }

        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PackageId { get; set; }

        [Required]
        public RightsType Type { get; set; }

        public DateTime? Expires { get; set; }

        public virtual User User { get; set; }

        public virtual Package Package { get; set; }
    }

    public class Package
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }

    public enum FileType
    {
        text,
        image,
        audio,
        video,
        other
    };

    public class File
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string OwnerEmail { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public virtual byte[] Data { get; set; }

        [Required]
        public FileType Type { get; set; }

        [Required]
        public virtual User Owner { get; set; }

        public string Description { get; set; }

        public string Origin { get; set; }

        public DateTime? Date { get; set; }

        public virtual ICollection<Package> Packages { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }

    public class Tag
    {
        [Key, Required]
        public string Text { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}
