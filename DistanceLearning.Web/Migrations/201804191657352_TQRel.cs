namespace DistanceLearning.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TQRel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "WrongAnswer1", c => c.String());
            AddColumn("dbo.Questions", "WrongAnswer2", c => c.String());
            AddColumn("dbo.Questions", "WrongAnswer3", c => c.String());
            AddColumn("dbo.Questions", "TestId", c => c.Int());
            CreateIndex("dbo.Questions", "TestId");
            AddForeignKey("dbo.Questions", "TestId", "dbo.Tests", "Id");
            DropColumn("dbo.Questions", "IdTest");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "IdTest", c => c.Int(nullable: false));
            DropForeignKey("dbo.Questions", "TestId", "dbo.Tests");
            DropIndex("dbo.Questions", new[] { "TestId" });
            DropColumn("dbo.Questions", "TestId");
            DropColumn("dbo.Questions", "WrongAnswer3");
            DropColumn("dbo.Questions", "WrongAnswer2");
            DropColumn("dbo.Questions", "WrongAnswer1");
        }
    }
}
