namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAddressesPlayerRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "playerId", "dbo.Players");
            DropIndex("dbo.Addresses", new[] { "playerId" });
            DropColumn("dbo.Addresses", "playerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "playerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "playerId");
            AddForeignKey("dbo.Addresses", "playerId", "dbo.Players", "playerId", cascadeDelete: true);
        }
    }
}
