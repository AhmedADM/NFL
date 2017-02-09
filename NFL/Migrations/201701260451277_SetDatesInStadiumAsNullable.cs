namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDatesInStadiumAsNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.partyAddresses", "to", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.partyAddresses", "to", c => c.DateTime(nullable: false));
        }
    }
}
