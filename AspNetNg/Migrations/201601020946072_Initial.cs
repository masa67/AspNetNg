namespace AspNetNg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dog",
                c => new
                    {
                        DogId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Breed = c.String(),
                    })
                .PrimaryKey(t => t.DogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dog");
        }
    }
}
