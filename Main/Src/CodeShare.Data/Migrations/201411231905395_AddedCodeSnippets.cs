namespace CodeShare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCodeSnippets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CodeSnippet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModicationDate = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Tag", "CodeSnippet_Id", c => c.Int());
            CreateIndex("dbo.Tag", "CodeSnippet_Id");
            AddForeignKey("dbo.Tag", "CodeSnippet_Id", "dbo.CodeSnippet", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CodeSnippet", "User_Id", "dbo.User");
            DropForeignKey("dbo.Tag", "CodeSnippet_Id", "dbo.CodeSnippet");
            DropIndex("dbo.CodeSnippet", new[] { "User_Id" });
            DropIndex("dbo.Tag", new[] { "CodeSnippet_Id" });
            DropColumn("dbo.Tag", "CodeSnippet_Id");
            DropTable("dbo.CodeSnippet");
        }
    }
}
