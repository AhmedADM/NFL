namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePlayerContactInformationRelation_Part2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Emails", "contactInformationId");
            CreateIndex("dbo.Faxes", "contactInformationId");
            CreateIndex("dbo.Phones", "contactInformationId");
            AddForeignKey("dbo.Emails", "contactInformationId", "dbo.ContactInformations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Faxes", "contactInformationId", "dbo.ContactInformations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Phones", "contactInformationId", "dbo.ContactInformations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "contactInformationId", "dbo.ContactInformations");
            DropForeignKey("dbo.Faxes", "contactInformationId", "dbo.ContactInformations");
            DropForeignKey("dbo.Emails", "contactInformationId", "dbo.ContactInformations");
            DropIndex("dbo.Phones", new[] { "contactInformationId" });
            DropIndex("dbo.Faxes", new[] { "contactInformationId" });
            DropIndex("dbo.Emails", new[] { "contactInformationId" });
        }
    }
}
