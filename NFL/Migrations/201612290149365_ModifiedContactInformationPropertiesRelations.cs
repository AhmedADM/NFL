namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedContactInformationPropertiesRelations : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Emails", "contactInformationId");
            DropColumn("dbo.Faxes", "contactInformationId");
            DropColumn("dbo.Phones", "contactInformationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Phones", "contactInformationId", c => c.Int(nullable: false));
            AddColumn("dbo.Faxes", "contactInformationId", c => c.Int(nullable: false));
            AddColumn("dbo.Emails", "contactInformationId", c => c.Int(nullable: false));
        }
    }
}
