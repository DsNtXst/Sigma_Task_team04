namespace DistanceLearning.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Lessons", name: "Course_Id", newName: "CourseId_Id");
            RenameColumn(table: "dbo.Courses", name: "Lector_Email", newName: "LectorId_Email");
            RenameIndex(table: "dbo.Courses", name: "IX_Lector_Email", newName: "IX_LectorId_Email");
            RenameIndex(table: "dbo.Lessons", name: "IX_Course_Id", newName: "IX_CourseId_Id");
            AddColumn("dbo.Tests", "CourseId_Id", c => c.Int());
            CreateIndex("dbo.Tests", "CourseId_Id");
            AddForeignKey("dbo.Tests", "CourseId_Id", "dbo.Courses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "CourseId_Id", "dbo.Courses");
            DropIndex("dbo.Tests", new[] { "CourseId_Id" });
            DropColumn("dbo.Tests", "CourseId_Id");
            RenameIndex(table: "dbo.Lessons", name: "IX_CourseId_Id", newName: "IX_Course_Id");
            RenameIndex(table: "dbo.Courses", name: "IX_LectorId_Email", newName: "IX_Lector_Email");
            RenameColumn(table: "dbo.Courses", name: "LectorId_Email", newName: "Lector_Email");
            RenameColumn(table: "dbo.Lessons", name: "CourseId_Id", newName: "Course_Id");
        }
    }
}
