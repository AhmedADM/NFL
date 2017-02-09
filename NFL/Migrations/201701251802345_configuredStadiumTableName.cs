namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configuredStadiumTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Stadium", newName: "Stadium");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Stadium", newName: "Stadium");
        }
    }
}
