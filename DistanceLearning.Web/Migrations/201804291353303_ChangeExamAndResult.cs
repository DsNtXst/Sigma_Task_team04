namespace DistanceLearning.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeExamAndResult : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "Status", c => c.Byte(nullable: false));
            DropColumn("dbo.Tests", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tests", "Status", c => c.Byte());
            DropColumn("dbo.Results", "Status");
        }
    }
}
