namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnknownChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stadium", "AddressId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stadium", "AddressId", c => c.String());
        }
    }
}
