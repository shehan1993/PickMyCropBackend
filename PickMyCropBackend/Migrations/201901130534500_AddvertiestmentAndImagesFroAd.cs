namespace PickMyCropBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddvertiestmentAndImagesFroAd : DbMigration
    {
        public override void Up()
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
                    })
                .PrimaryKey(t => t.price);
            
            CreateTable(
                "dbo.tblImagesForAd",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        AdvertiestmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblImagesForAd");
            DropTable("dbo.tblAdvertiestment");
        }
    }
}
