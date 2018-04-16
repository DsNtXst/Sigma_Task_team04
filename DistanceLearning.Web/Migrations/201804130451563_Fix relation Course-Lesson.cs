namespace DistanceLearning.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixrelationCourseLesson : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lessons", "CourseId_Id", "dbo.Courses");
            DropIndex("dbo.Lessons", new[] { "CourseId_Id" });
            RenameColumn(table: "dbo.Lessons", name: "CourseId_Id", newName: "CourseId");
            AlterColumn("dbo.Lessons", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Lessons", "CourseId");
            AddForeignKey("dbo.Lessons", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "CourseId", "dbo.Courses");
            DropIndex("dbo.Lessons", new[] { "CourseId" });
            AlterColumn("dbo.Lessons", "CourseId", c => c.Int());
            RenameColumn(table: "dbo.Lessons", name: "CourseId", newName: "CourseId_Id");
            CreateIndex("dbo.Lessons", "CourseId_Id");
            AddForeignKey("dbo.Lessons", "CourseId_Id", "dbo.Courses", "Id");
        }
    }
}
