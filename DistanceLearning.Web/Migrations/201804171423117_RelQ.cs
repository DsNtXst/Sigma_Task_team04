namespace DistanceLearning.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelQ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "WrongAnswer1", c => c.String());
            AddColumn("dbo.Questions", "WrongAnswer2", c => c.String());
            AddColumn("dbo.Questions", "WrongAnswer3", c => c.String());
            DropColumn("dbo.Questions", "WAnswer1");
            DropColumn("dbo.Questions", "WAnswer2");
            DropColumn("dbo.Questions", "WAnswer3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "WAnswer3", c => c.String());
            AddColumn("dbo.Questions", "WAnswer2", c => c.String());
            AddColumn("dbo.Questions", "WAnswer1", c => c.String());
            DropColumn("dbo.Questions", "WrongAnswer3");
            DropColumn("dbo.Questions", "WrongAnswer2");
            DropColumn("dbo.Questions", "WrongAnswer1");
        }
    }
}
