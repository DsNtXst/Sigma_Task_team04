namespace DistanceLearning.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Res : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                        Progress = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Results");
        }
    }
}
