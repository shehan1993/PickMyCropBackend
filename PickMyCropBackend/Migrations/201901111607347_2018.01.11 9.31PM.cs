namespace PickMyCropBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180111931PM : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.tblQuestion", new[] { "starter_ID" });
            AddColumn("dbo.tblQuestion", "question", c => c.String(unicode: false));
            AlterColumn("dbo.tblQuestion", "starter_Id", c => c.String(maxLength: 128, storeType: "nvarchar"));
            CreateIndex("dbo.tblQuestion", "starter_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.tblQuestion", new[] { "starter_Id" });
            AlterColumn("dbo.tblQuestion", "starter_Id", c => c.Int());
            DropColumn("dbo.tblQuestion", "question");
            CreateIndex("dbo.tblQuestion", "starter_ID");
        }
    }
}
