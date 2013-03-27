namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.Rights",
                c => new
                    {
                        UserEmail = c.String(nullable: false, maxLength: 128),
                        PackageId = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Expires = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.UserEmail, t.PackageId })
                .ForeignKey("dbo.Users", t => t.UserEmail, cascadeDelete: true)
                .ForeignKey("dbo.Packages", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.UserEmail)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerEmail = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Data = c.Binary(nullable: false),
                        Type = c.Int(nullable: false),
                        Description = c.String(),
                        Origin = c.String(),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerEmail, cascadeDelete: true)
                .Index(t => t.OwnerEmail);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Text = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Text);
            
            CreateTable(
                "dbo.FilePackages",
                c => new
                    {
                        File_Id = c.Int(nullable: false),
                        Package_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.File_Id, t.Package_Id })
                .ForeignKey("dbo.Files", t => t.File_Id, cascadeDelete: true)
                .ForeignKey("dbo.Packages", t => t.Package_Id, cascadeDelete: true)
                .Index(t => t.File_Id)
                .Index(t => t.Package_Id);
            
            CreateTable(
                "dbo.TagFiles",
                c => new
                    {
                        Tag_Text = c.String(nullable: false, maxLength: 128),
                        File_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Text, t.File_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Text, cascadeDelete: true)
                .ForeignKey("dbo.Files", t => t.File_Id, cascadeDelete: true)
                .Index(t => t.Tag_Text)
                .Index(t => t.File_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TagFiles", new[] { "File_Id" });
            DropIndex("dbo.TagFiles", new[] { "Tag_Text" });
            DropIndex("dbo.FilePackages", new[] { "Package_Id" });
            DropIndex("dbo.FilePackages", new[] { "File_Id" });
            DropIndex("dbo.Files", new[] { "OwnerEmail" });
            DropIndex("dbo.Rights", new[] { "PackageId" });
            DropIndex("dbo.Rights", new[] { "UserEmail" });
            DropForeignKey("dbo.TagFiles", "File_Id", "dbo.Files");
            DropForeignKey("dbo.TagFiles", "Tag_Text", "dbo.Tags");
            DropForeignKey("dbo.FilePackages", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.FilePackages", "File_Id", "dbo.Files");
            DropForeignKey("dbo.Files", "OwnerEmail", "dbo.Users");
            DropForeignKey("dbo.Rights", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Rights", "UserEmail", "dbo.Users");
            DropTable("dbo.TagFiles");
            DropTable("dbo.FilePackages");
            DropTable("dbo.Tags");
            DropTable("dbo.Files");
            DropTable("dbo.Packages");
            DropTable("dbo.Rights");
            DropTable("dbo.Users");
        }
    }
}
