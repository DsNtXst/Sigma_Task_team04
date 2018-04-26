namespace DistanceLearning.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NRes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "UserEmail", c => c.String());
            DropColumn("dbo.Results", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Results", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Results", "UserEmail");
        }
    }
}
