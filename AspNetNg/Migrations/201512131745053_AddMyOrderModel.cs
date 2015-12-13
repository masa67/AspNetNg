namespace AspNetNg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMyOrderModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyOrderDetailModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MyOrderModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MyOrderModel", t => t.MyOrderModel_Id)
                .Index(t => t.MyOrderModel_Id);
            
            CreateTable(
                "dbo.MyOrderModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyOrderDetailModel", "MyOrderModel_Id", "dbo.MyOrderModel");
            DropIndex("dbo.MyOrderDetailModel", new[] { "MyOrderModel_Id" });
            DropTable("dbo.MyOrderModel");
            DropTable("dbo.MyOrderDetailModel");
        }
    }
}
