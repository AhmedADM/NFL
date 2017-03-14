namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldTOContactInformationPersonalInformation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactInformations", "Person", c => c.String());
            AddColumn("dbo.PersonalInformations", "Person", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonalInformations", "Person");
            DropColumn("dbo.ContactInformations", "Person");
        }
    }
}
