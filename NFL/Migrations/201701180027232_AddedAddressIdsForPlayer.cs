namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAddressIdsForPlayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "AddressIds", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "AddressIds");
        }
    }
}
