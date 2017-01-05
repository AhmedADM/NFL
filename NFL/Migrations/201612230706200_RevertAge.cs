namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertAge : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PersonalInformations", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonalInformations", "Age", c => c.Byte(nullable: false));
        }
    }
}
