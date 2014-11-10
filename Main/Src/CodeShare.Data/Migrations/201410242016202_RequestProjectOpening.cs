namespace CodeShare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestProjectOpening : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectUserRequest", "RelatedOpening_Id", c => c.Int());
            CreateIndex("dbo.ProjectUserRequest", "RelatedOpening_Id");
            AddForeignKey("dbo.ProjectUserRequest", "RelatedOpening_Id", "dbo.ProjectOpening", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectUserRequest", "RelatedOpening_Id", "dbo.ProjectOpening");
            DropIndex("dbo.ProjectUserRequest", new[] { "RelatedOpening_Id" });
            DropColumn("dbo.ProjectUserRequest", "RelatedOpening_Id");
        }
    }
}
