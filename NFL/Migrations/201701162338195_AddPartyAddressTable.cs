namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPartyAddressTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.partyAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        partyId = c.Int(nullable: false),
                        addressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.partyAddresses");
        }
    }
}
