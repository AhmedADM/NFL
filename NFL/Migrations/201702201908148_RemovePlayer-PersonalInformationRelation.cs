namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePlayerPersonalInformationRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonalInformations", "playerId", "dbo.Players");
            DropIndex("dbo.PersonalInformations", new[] { "playerId" });
            DropPrimaryKey("dbo.PersonalInformations");
            AddColumn("dbo.PersonalInformations", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.PersonalInformations", "personId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PersonalInformations", "Id");
            DropColumn("dbo.PersonalInformations", "playerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonalInformations", "playerId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.PersonalInformations");
            DropColumn("dbo.PersonalInformations", "personId");
            DropColumn("dbo.PersonalInformations", "Id");
            AddPrimaryKey("dbo.PersonalInformations", "playerId");
            CreateIndex("dbo.PersonalInformations", "playerId");
            AddForeignKey("dbo.PersonalInformations", "playerId", "dbo.Players", "playerId");
        }
    }
}
