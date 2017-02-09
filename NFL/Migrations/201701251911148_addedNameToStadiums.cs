namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNameToStadiums : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stadium", "Names", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stadium", "Names");
        }
    }
}
