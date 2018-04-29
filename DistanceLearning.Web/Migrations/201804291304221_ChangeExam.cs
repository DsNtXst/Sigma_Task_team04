namespace DistanceLearning.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeExam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "Status", c => c.Byte());
            DropColumn("dbo.Tests", "IsConfirmed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tests", "IsConfirmed", c => c.Boolean());
            DropColumn("dbo.Tests", "Status");
        }
    }
}
