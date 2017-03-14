namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedTableOffensiveCoaches : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OffensiveCoaches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OffensiveCoordinator_Id = c.Int(),
                        QuarterbackCoach_Id = c.Int(),
                        RunGameCoordinator_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.OffensiveCoordinator_Id)
                .ForeignKey("dbo.Employees", t => t.QuarterbackCoach_Id)
                .ForeignKey("dbo.Employees", t => t.RunGameCoordinator_Id)
                .Index(t => t.OffensiveCoordinator_Id)
                .Index(t => t.QuarterbackCoach_Id)
                .Index(t => t.RunGameCoordinator_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OffensiveCoaches", "RunGameCoordinator_Id", "dbo.Employees");
            DropForeignKey("dbo.OffensiveCoaches", "QuarterbackCoach_Id", "dbo.Employees");
            DropForeignKey("dbo.OffensiveCoaches", "OffensiveCoordinator_Id", "dbo.Employees");
            DropIndex("dbo.OffensiveCoaches", new[] { "RunGameCoordinator_Id" });
            DropIndex("dbo.OffensiveCoaches", new[] { "QuarterbackCoach_Id" });
            DropIndex("dbo.OffensiveCoaches", new[] { "OffensiveCoordinator_Id" });
            DropTable("dbo.OffensiveCoaches");
        }
    }
}
