namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStadiumTable : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                 "dbo.Stadium",
                 c => new
                 {
                     Id = c.Int(nullable: false, identity: true),
                     DateEstablished = c.DateTime(nullable: false),
                     Capacity = c.Int(nullable: false),
                     Address_Id = c.Int(),
                 })
                 .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {

            DropTable("dbo.Stadium");
        }
    }
}
