namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedTableExperience : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Organization = c.String(nullable: false),
                        Role = c.String(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(),
                        Description = c.String(),
                        personId = c.Int(nullable: false),
                        Person = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Experiences");
        }
    }
}
