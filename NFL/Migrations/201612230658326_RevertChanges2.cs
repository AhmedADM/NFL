namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertChanges2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonalInformations", "Age", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonalInformations", "Age");
        }
    }
}
