namespace PickMyCropBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtablestomaincontext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblVegCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblQuestion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(unicode: false),
                        votes = c.Int(nullable: false),
                        starter_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.starter_ID)
                .Index(t => t.starter_ID);
            
            CreateTable(
                "dbo.tblAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answar = c.String(nullable: false, unicode: false),
                        vots = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        user_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblQuestion", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.user_ID)
                .Index(t => t.QuestionId)
                .Index(t => t.user_ID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        UserName = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        ContactNumber = c.Int(nullable: false),
                        AddressLine_1 = c.String(unicode: false),
                        AddressLine_2 = c.String(unicode: false),
                        City = c.String(unicode: false),
                        Details = c.String(unicode: false),
                        Image = c.String(unicode: false),
                        LoggedOn = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.QuestiontVegCategory",
                c => new
                    {
                        QuestiontRefId = c.Int(nullable: false),
                        VegCategoryRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestiontRefId, t.VegCategoryRefId })
                .ForeignKey("dbo.tblQuestion", t => t.QuestiontRefId, cascadeDelete: true)
                .ForeignKey("dbo.tblVegCategory", t => t.VegCategoryRefId, cascadeDelete: true)
                .Index(t => t.QuestiontRefId)
                .Index(t => t.VegCategoryRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestiontVegCategory", "VegCategoryRefId", "dbo.tblVegCategory");
            DropForeignKey("dbo.QuestiontVegCategory", "QuestiontRefId", "dbo.tblQuestion");
            DropForeignKey("dbo.tblQuestion", "starter_ID", "dbo.People");
            DropForeignKey("dbo.tblAnswers", "user_ID", "dbo.People");
            DropForeignKey("dbo.tblAnswers", "QuestionId", "dbo.tblQuestion");
            DropIndex("dbo.QuestiontVegCategory", new[] { "VegCategoryRefId" });
            DropIndex("dbo.QuestiontVegCategory", new[] { "QuestiontRefId" });
            DropIndex("dbo.tblAnswers", new[] { "user_ID" });
            DropIndex("dbo.tblAnswers", new[] { "QuestionId" });
            DropIndex("dbo.tblQuestion", new[] { "starter_ID" });
            DropTable("dbo.QuestiontVegCategory");
            DropTable("dbo.People");
            DropTable("dbo.tblAnswers");
            DropTable("dbo.tblQuestion");
            DropTable("dbo.tblVegCategory");
        }
    }
}
