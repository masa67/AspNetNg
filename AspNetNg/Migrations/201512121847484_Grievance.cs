namespace AspNetNg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Grievance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Action",
                c => new
                    {
                        ActionId = c.Guid(nullable: false),
                        GrievanceStep_GrievanceStepID = c.Guid(),
                    })
                .PrimaryKey(t => t.ActionId)
                .ForeignKey("dbo.GrievanceStep", t => t.GrievanceStep_GrievanceStepID)
                .Index(t => t.GrievanceStep_GrievanceStepID);
            
            CreateTable(
                "dbo.ActionDirectory",
                c => new
                    {
                        ActionID = c.Guid(nullable: false),
                        DirectoryID = c.Guid(nullable: false),
                        GrievanceStepID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ActionID)
                .ForeignKey("dbo.Action", t => t.ActionID)
                .ForeignKey("dbo.Filesystem", t => t.DirectoryID, cascadeDelete: true)
                .ForeignKey("dbo.GrievanceStep", t => t.GrievanceStepID, cascadeDelete: true)
                .Index(t => t.ActionID)
                .Index(t => t.DirectoryID)
                .Index(t => t.GrievanceStepID);
            
            CreateTable(
                "dbo.Filesystem",
                c => new
                    {
                        DirectoryID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.DirectoryID);
            
            CreateTable(
                "dbo.GrievanceStep",
                c => new
                    {
                        GrievanceStepId = c.Guid(nullable: false),
                        GrievanceID = c.Guid(),
                    })
                .PrimaryKey(t => t.GrievanceStepId)
                .ForeignKey("dbo.Grievance", t => t.GrievanceID)
                .Index(t => t.GrievanceID);
            
            CreateTable(
                "dbo.Grievance",
                c => new
                    {
                        GrievanceId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.GrievanceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GrievanceStep", "GrievanceID", "dbo.Grievance");
            DropForeignKey("dbo.Action", "GrievanceStep_GrievanceStepID", "dbo.GrievanceStep");
            DropForeignKey("dbo.ActionDirectory", "GrievanceStepID", "dbo.GrievanceStep");
            DropForeignKey("dbo.ActionDirectory", "DirectoryID", "dbo.Filesystem");
            DropForeignKey("dbo.ActionDirectory", "ActionID", "dbo.Action");
            DropIndex("dbo.GrievanceStep", new[] { "GrievanceID" });
            DropIndex("dbo.ActionDirectory", new[] { "GrievanceStepID" });
            DropIndex("dbo.ActionDirectory", new[] { "DirectoryID" });
            DropIndex("dbo.ActionDirectory", new[] { "ActionID" });
            DropIndex("dbo.Action", new[] { "GrievanceStep_GrievanceStepID" });
            DropTable("dbo.Grievance");
            DropTable("dbo.GrievanceStep");
            DropTable("dbo.Filesystem");
            DropTable("dbo.ActionDirectory");
            DropTable("dbo.Action");
        }
    }
}
