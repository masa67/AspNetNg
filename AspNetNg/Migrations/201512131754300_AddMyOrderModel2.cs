namespace AspNetNg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMyOrderModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyOrderModel", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyOrderModel", "Discriminator");
        }
    }
}
