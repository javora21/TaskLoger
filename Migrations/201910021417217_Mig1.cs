namespace TaskLoger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ticket = c.String(nullable: false),
                        Description = c.String(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.TaskList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        CancelDate = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Task", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskList", "TaskId", "dbo.Task");
            DropForeignKey("dbo.Task", "ProjectId", "dbo.Project");
            DropIndex("dbo.TaskList", new[] { "TaskId" });
            DropIndex("dbo.Task", new[] { "ProjectId" });
            DropTable("dbo.TaskList");
            DropTable("dbo.Task");
            DropTable("dbo.Project");
        }
    }
}
