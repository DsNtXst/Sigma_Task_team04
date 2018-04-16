namespace DistanceLearning.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TRel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.Tests", "CourseId_Id", "dbo.Courses");
            DropIndex("dbo.Tests", new[] { "CourseId_Id" });
            DropIndex("dbo.Questions", new[] { "Test_Id" });
            RenameColumn(table: "dbo.Tests", name: "CourseId_Id", newName: "CourseId");
            AlterColumn("dbo.Tests", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tests", "CourseId");
            AddForeignKey("dbo.Tests", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            DropColumn("dbo.Questions", "Test_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Test_Id", c => c.Int());
            DropForeignKey("dbo.Tests", "CourseId", "dbo.Courses");
            DropIndex("dbo.Tests", new[] { "CourseId" });
            AlterColumn("dbo.Tests", "CourseId", c => c.Int());
            RenameColumn(table: "dbo.Tests", name: "CourseId", newName: "CourseId_Id");
            CreateIndex("dbo.Questions", "Test_Id");
            CreateIndex("dbo.Tests", "CourseId_Id");
            AddForeignKey("dbo.Tests", "CourseId_Id", "dbo.Courses", "Id");
            AddForeignKey("dbo.Questions", "Test_Id", "dbo.Tests", "Id");
        }
    }
}
