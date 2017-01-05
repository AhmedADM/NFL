namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLocationInsteadOfCities : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Cities", newName: "Locations");
            RenameColumn(table: "dbo.Addresses", name: "cityId", newName: "locationId");
            RenameIndex(table: "dbo.Addresses", name: "IX_cityId", newName: "IX_locationId");
            AddColumn("dbo.Locations", "County", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "County");
            RenameIndex(table: "dbo.Addresses", name: "IX_locationId", newName: "IX_cityId");
            RenameColumn(table: "dbo.Addresses", name: "locationId", newName: "cityId");
            RenameTable(name: "dbo.Locations", newName: "Cities");
        }
    }
}
