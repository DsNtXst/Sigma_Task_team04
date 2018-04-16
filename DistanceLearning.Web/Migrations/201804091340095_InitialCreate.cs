namespace DistanceLearning.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Hours = c.Int(nullable: false),
                        Mark = c.Int(nullable: false),
                        Exam_Id = c.Int(),
                        Lector_Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.Exam_Id)
                .ForeignKey("dbo.Lectors", t => t.Lector_Email)
                .Index(t => t.Exam_Id)
                .Index(t => t.Lector_Email);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountQuestions = c.Int(nullable: false),
                        Time = c.Time(nullable: false, precision: 7),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Task = c.String(),
                        TrueAnswer = c.String(),
                        Test_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.Test_Id)
                .Index(t => t.Test_Id);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Information = c.String(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Lectors",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        MiddleName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Lector_Email", "dbo.Lectors");
            DropForeignKey("dbo.Tests", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Lessons", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "Exam_Id", "dbo.Tests");
            DropForeignKey("dbo.Questions", "Test_Id", "dbo.Tests");
            DropIndex("dbo.Lessons", new[] { "Course_Id" });
            DropIndex("dbo.Questions", new[] { "Test_Id" });
            DropIndex("dbo.Tests", new[] { "Course_Id" });
            DropIndex("dbo.Courses", new[] { "Lector_Email" });
            DropIndex("dbo.Courses", new[] { "Exam_Id" });
            DropTable("dbo.Lectors");
            DropTable("dbo.Lessons");
            DropTable("dbo.Questions");
            DropTable("dbo.Tests");
            DropTable("dbo.Courses");
        }
    }
}
