namespace PickMyCropBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvegidtoadvert : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblAdvertisetment", "vegid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblAdvertisetment", "vegid");
        }
    }
}
