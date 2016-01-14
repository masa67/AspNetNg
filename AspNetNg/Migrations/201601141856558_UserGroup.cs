namespace AspNetNg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserGroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserGroup",
                c => new
                    {
                        User_ID = c.Int(nullable: false),
                        Group_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_ID, t.Group_ID })
                .ForeignKey("dbo.User", t => t.User_ID, cascadeDelete: true)
                .ForeignKey("dbo.Group", t => t.Group_ID, cascadeDelete: true)
                .Index(t => t.User_ID)
                .Index(t => t.Group_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGroup", "Group_ID", "dbo.Group");
            DropForeignKey("dbo.UserGroup", "User_ID", "dbo.User");
            DropIndex("dbo.UserGroup", new[] { "Group_ID" });
            DropIndex("dbo.UserGroup", new[] { "User_ID" });
            DropTable("dbo.UserGroup");
            DropTable("dbo.User");
            DropTable("dbo.Group");
        }
    }
}
