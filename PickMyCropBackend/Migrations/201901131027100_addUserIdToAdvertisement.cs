namespace PickMyCropBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserIdToAdvertisement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblAdvertiestment", "userId", c => c.String(unicode: false));
            AddColumn("dbo.tblImagesForAd", "AdvertisetmentId", c => c.Int(nullable: false));
            DropColumn("dbo.tblImagesForAd", "AdvertiestmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblImagesForAd", "AdvertiestmentId", c => c.Int(nullable: false));
            DropColumn("dbo.tblImagesForAd", "AdvertisetmentId");
            DropColumn("dbo.tblAdvertiestment", "userId");
        }
    }
}
