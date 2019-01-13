namespace PickMyCropBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class advert : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAdvertisetment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        price = c.Int(nullable: false),
                        amount = c.Int(nullable: false),
                        vegtype = c.String(unicode: false),
                        lat = c.Double(nullable: false),
                        lng = c.Double(nullable: false),
                        userId = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblAdvertisetment");
        }
    }
}
