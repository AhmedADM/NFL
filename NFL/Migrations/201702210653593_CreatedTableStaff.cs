namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedTableStaff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        frontOffice_Id = c.Int(),
                        offensiveCoaches_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FrontOffices", t => t.frontOffice_Id)
                .ForeignKey("dbo.OffensiveCoaches", t => t.offensiveCoaches_Id)
                .Index(t => t.frontOffice_Id)
                .Index(t => t.offensiveCoaches_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "offensiveCoaches_Id", "dbo.OffensiveCoaches");
            DropForeignKey("dbo.Staffs", "frontOffice_Id", "dbo.FrontOffices");
            DropIndex("dbo.Staffs", new[] { "offensiveCoaches_Id" });
            DropIndex("dbo.Staffs", new[] { "frontOffice_Id" });
            DropTable("dbo.Staffs");
        }
    }
}
