namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePlayerContactInformationRelation_Part1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Emails", "contactInformation_playerId", "dbo.ContactInformations");
            DropForeignKey("dbo.Faxes", "contactInformation_playerId", "dbo.ContactInformations");
            DropForeignKey("dbo.Phones", "contactInformation_playerId", "dbo.ContactInformations");
            DropForeignKey("dbo.ContactInformations", "playerId", "dbo.Players");
            DropIndex("dbo.ContactInformations", new[] { "playerId" });
            DropIndex("dbo.Emails", new[] { "contactInformation_playerId" });
            DropIndex("dbo.Faxes", new[] { "contactInformation_playerId" });
            DropIndex("dbo.Phones", new[] { "contactInformation_playerId" });
            DropPrimaryKey("dbo.ContactInformations");
            AddColumn("dbo.ContactInformations", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ContactInformations", "personId", c => c.Int(nullable: false));
            AddColumn("dbo.Emails", "contactInformationId", c => c.Int(nullable: false));
            AddColumn("dbo.Faxes", "contactInformationId", c => c.Int(nullable: false));
            AddColumn("dbo.Phones", "contactInformationId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ContactInformations", "Id");
            DropColumn("dbo.ContactInformations", "playerId");
            DropColumn("dbo.Emails", "contactInformation_playerId");
            DropColumn("dbo.Faxes", "contactInformation_playerId");
            DropColumn("dbo.Phones", "contactInformation_playerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Phones", "contactInformation_playerId", c => c.Int());
            AddColumn("dbo.Faxes", "contactInformation_playerId", c => c.Int());
            AddColumn("dbo.Emails", "contactInformation_playerId", c => c.Int());
            AddColumn("dbo.ContactInformations", "playerId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.ContactInformations");
            DropColumn("dbo.Phones", "contactInformationId");
            DropColumn("dbo.Faxes", "contactInformationId");
            DropColumn("dbo.Emails", "contactInformationId");
            DropColumn("dbo.ContactInformations", "personId");
            DropColumn("dbo.ContactInformations", "Id");
            AddPrimaryKey("dbo.ContactInformations", "playerId");
            CreateIndex("dbo.Phones", "contactInformation_playerId");
            CreateIndex("dbo.Faxes", "contactInformation_playerId");
            CreateIndex("dbo.Emails", "contactInformation_playerId");
            CreateIndex("dbo.ContactInformations", "playerId");
            AddForeignKey("dbo.ContactInformations", "playerId", "dbo.Players", "playerId");
            AddForeignKey("dbo.Phones", "contactInformation_playerId", "dbo.ContactInformations", "playerId");
            AddForeignKey("dbo.Faxes", "contactInformation_playerId", "dbo.ContactInformations", "playerId");
            AddForeignKey("dbo.Emails", "contactInformation_playerId", "dbo.ContactInformations", "playerId");
        }
    }
}
