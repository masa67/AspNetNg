namespace AspNetNg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TravelRequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resource",
                c => new
                    {
                        ResourceID = c.Int(nullable: false, identity: true),
                        ResourceName = c.String(),
                    })
                .PrimaryKey(t => t.ResourceID);
            
            CreateTable(
                "dbo.TravelRequest",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        ResourceID = c.Int(),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.Resource", t => t.ResourceID)
                .Index(t => t.ResourceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TravelRequest", "ResourceID", "dbo.Resource");
            DropIndex("dbo.TravelRequest", new[] { "ResourceID" });
            DropTable("dbo.TravelRequest");
            DropTable("dbo.Resource");
        }
    }
}
