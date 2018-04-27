namespace DistanceLearning.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "IsConfirmed", c => c.Boolean());
            AddColumn("dbo.Tests", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tests", "Discriminator");
            DropColumn("dbo.Tests", "IsConfirmed");
        }
    }
}
