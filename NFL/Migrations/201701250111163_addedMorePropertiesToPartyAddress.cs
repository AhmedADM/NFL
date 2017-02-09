namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedMorePropertiesToPartyAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.partyAddresses", "party", c => c.String());
            AddColumn("dbo.partyAddresses", "from", c => c.DateTime());
            AddColumn("dbo.partyAddresses", "to", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.partyAddresses", "to");
            DropColumn("dbo.partyAddresses", "from");
            DropColumn("dbo.partyAddresses", "party");
        }
    }
}
