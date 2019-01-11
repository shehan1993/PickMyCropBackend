namespace PickMyCropBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201801111018PM : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblAnswers", "Answar", c => c.String(nullable: true, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblAnswers", "Answar", c => c.String(nullable: false, unicode: false));
        }
    }
}
