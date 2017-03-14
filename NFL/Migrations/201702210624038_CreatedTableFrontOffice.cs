namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedTableFrontOffice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FrontOffices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CEO_Id = c.Int(),
                        OwnerCEO_Id = c.Int(),
                        Precident_Id = c.Int(),
                        SpecialAssistence_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.CEO_Id)
                .ForeignKey("dbo.Employees", t => t.OwnerCEO_Id)
                .ForeignKey("dbo.Employees", t => t.Precident_Id)
                .ForeignKey("dbo.Employees", t => t.SpecialAssistence_Id)
                .Index(t => t.CEO_Id)
                .Index(t => t.OwnerCEO_Id)
                .Index(t => t.Precident_Id)
                .Index(t => t.SpecialAssistence_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FrontOffices", "SpecialAssistence_Id", "dbo.Employees");
            DropForeignKey("dbo.FrontOffices", "Precident_Id", "dbo.Employees");
            DropForeignKey("dbo.FrontOffices", "OwnerCEO_Id", "dbo.Employees");
            DropForeignKey("dbo.FrontOffices", "CEO_Id", "dbo.Employees");
            DropIndex("dbo.FrontOffices", new[] { "SpecialAssistence_Id" });
            DropIndex("dbo.FrontOffices", new[] { "Precident_Id" });
            DropIndex("dbo.FrontOffices", new[] { "OwnerCEO_Id" });
            DropIndex("dbo.FrontOffices", new[] { "CEO_Id" });
            DropTable("dbo.FrontOffices");
        }
    }
}
