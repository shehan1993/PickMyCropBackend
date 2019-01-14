namespace PickMyCropBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vegcategoryImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblVegCategory", "Image", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblVegCategory", "Image");
        }
    }
}
