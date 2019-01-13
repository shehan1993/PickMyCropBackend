namespace PickMyCropBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeAdvertiesmnt : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.tblAdvertiestment");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tblAdvertiestment",
                c => new
                    {
                        price = c.Int(nullable: false, identity: true),
                        amount = c.Int(nullable: false),
                        vegtype = c.String(unicode: false),
                        lat = c.Double(nullable: false),
                        lng = c.Double(nullable: false),
                        userId = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.price);
            
        }
    }
}
