namespace AspNetNg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RootObject",
                c => new
                    {
                        RootObjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RootObjectId);
            
            CreateTable(
                "dbo.AObjects",
                c => new
                    {
                        RootObjectId = c.Int(nullable: false),
                        AField = c.String(),
                    })
                .PrimaryKey(t => t.RootObjectId)
                .ForeignKey("dbo.RootObject", t => t.RootObjectId)
                .Index(t => t.RootObjectId);
            
            CreateTable(
                "dbo.BObjects",
                c => new
                    {
                        RootObjectId = c.Int(nullable: false),
                        BField = c.String(),
                    })
                .PrimaryKey(t => t.RootObjectId)
                .ForeignKey("dbo.RootObject", t => t.RootObjectId)
                .Index(t => t.RootObjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BObjects", "RootObjectId", "dbo.RootObject");
            DropForeignKey("dbo.AObjects", "RootObjectId", "dbo.RootObject");
            DropIndex("dbo.BObjects", new[] { "RootObjectId" });
            DropIndex("dbo.AObjects", new[] { "RootObjectId" });
            DropTable("dbo.BObjects");
            DropTable("dbo.AObjects");
            DropTable("dbo.RootObject");
        }
    }
}
