namespace AspNetNg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthCodeToMyOrderModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyOrderModel", "AuthCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyOrderModel", "AuthCode");
        }
    }
}
