namespace CodeShare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectFile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Url = c.String(nullable: false, maxLength: 2083),
                        ProjectRelease_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectRelease", t => t.ProjectRelease_Id)
                .Index(t => t.ProjectRelease_Id);
            
            CreateTable(
                "dbo.ProjectOpening",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.Project_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        ProjectOpening_Id = c.Int(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectOpening", t => t.ProjectOpening_Id)
                .ForeignKey("dbo.Project", t => t.Project_Id)
                .Index(t => t.ProjectOpening_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.ProjectRelease",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreationDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        DownloadCount = c.Int(nullable: false),
                        ReleaseFile_Id = c.Int(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectFile", t => t.ReleaseFile_Id)
                .ForeignKey("dbo.Project", t => t.Project_Id)
                .Index(t => t.ReleaseFile_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        QuickDescription = c.String(nullable: false, maxLength: 140),
                        Description = c.String(),
                        LogoUrl = c.String(maxLength: 2083),
                        SourceUrl = c.String(maxLength: 2083),
                        CreationDate = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                        User_Id1 = c.Int(),
                        User_Id2 = c.Int(),
                        User_Id3 = c.Int(),
                        Creator_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .ForeignKey("dbo.User", t => t.User_Id1)
                .ForeignKey("dbo.User", t => t.User_Id2)
                .ForeignKey("dbo.User", t => t.User_Id3)
                .ForeignKey("dbo.ProjectUser", t => t.Creator_Id)
                .Index(t => t.User_Id)
                .Index(t => t.User_Id1)
                .Index(t => t.User_Id2)
                .Index(t => t.User_Id3)
                .Index(t => t.Creator_Id);
            
            CreateTable(
                "dbo.ProjectUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        Role = c.Int(nullable: false),
                        User_Id = c.Int(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .ForeignKey("dbo.Project", t => t.Project_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100),
                        NickName = c.String(maxLength: 100),
                        AvatarUrl = c.String(maxLength: 2083),
                        JoinDate = c.DateTime(nullable: false),
                        Project_Id = c.Int(),
                        Project_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.Project_Id)
                .ForeignKey("dbo.Project", t => t.Project_Id1)
                .Index(t => t.Project_Id)
                .Index(t => t.Project_Id1);
            
            CreateTable(
                "dbo.ProjectUserRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false, maxLength: 140),
                        User_Id = c.Int(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .ForeignKey("dbo.Project", t => t.Project_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Project_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tag", "Project_Id", "dbo.Project");
            DropForeignKey("dbo.ProjectRelease", "Project_Id", "dbo.Project");
            DropForeignKey("dbo.ProjectOpening", "Project_Id", "dbo.Project");
            DropForeignKey("dbo.ProjectUser", "Project_Id", "dbo.Project");
            DropForeignKey("dbo.ProjectUserRequest", "Project_Id", "dbo.Project");
            DropForeignKey("dbo.ProjectUserRequest", "User_Id", "dbo.User");
            DropForeignKey("dbo.User", "Project_Id1", "dbo.Project");
            DropForeignKey("dbo.User", "Project_Id", "dbo.Project");
            DropForeignKey("dbo.Project", "Creator_Id", "dbo.ProjectUser");
            DropForeignKey("dbo.ProjectUser", "User_Id", "dbo.User");
            DropForeignKey("dbo.Project", "User_Id3", "dbo.User");
            DropForeignKey("dbo.Project", "User_Id2", "dbo.User");
            DropForeignKey("dbo.Project", "User_Id1", "dbo.User");
            DropForeignKey("dbo.Project", "User_Id", "dbo.User");
            DropForeignKey("dbo.ProjectRelease", "ReleaseFile_Id", "dbo.ProjectFile");
            DropForeignKey("dbo.ProjectFile", "ProjectRelease_Id", "dbo.ProjectRelease");
            DropForeignKey("dbo.Tag", "ProjectOpening_Id", "dbo.ProjectOpening");
            DropIndex("dbo.ProjectUserRequest", new[] { "Project_Id" });
            DropIndex("dbo.ProjectUserRequest", new[] { "User_Id" });
            DropIndex("dbo.User", new[] { "Project_Id1" });
            DropIndex("dbo.User", new[] { "Project_Id" });
            DropIndex("dbo.ProjectUser", new[] { "Project_Id" });
            DropIndex("dbo.ProjectUser", new[] { "User_Id" });
            DropIndex("dbo.Project", new[] { "Creator_Id" });
            DropIndex("dbo.Project", new[] { "User_Id3" });
            DropIndex("dbo.Project", new[] { "User_Id2" });
            DropIndex("dbo.Project", new[] { "User_Id1" });
            DropIndex("dbo.Project", new[] { "User_Id" });
            DropIndex("dbo.ProjectRelease", new[] { "Project_Id" });
            DropIndex("dbo.ProjectRelease", new[] { "ReleaseFile_Id" });
            DropIndex("dbo.Tag", new[] { "Project_Id" });
            DropIndex("dbo.Tag", new[] { "ProjectOpening_Id" });
            DropIndex("dbo.ProjectOpening", new[] { "Project_Id" });
            DropIndex("dbo.ProjectFile", new[] { "ProjectRelease_Id" });
            DropTable("dbo.ProjectUserRequest");
            DropTable("dbo.User");
            DropTable("dbo.ProjectUser");
            DropTable("dbo.Project");
            DropTable("dbo.ProjectRelease");
            DropTable("dbo.Tag");
            DropTable("dbo.ProjectOpening");
            DropTable("dbo.ProjectFile");
        }
    }
}
