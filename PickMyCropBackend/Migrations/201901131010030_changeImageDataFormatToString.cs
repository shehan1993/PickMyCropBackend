namespace PickMyCropBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeImageDataFormatToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblImagesForAd", "Image", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblImagesForAd", "Image", c => c.Binary());
        }
    }
}
