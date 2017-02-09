namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedEmailValidationSelectType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Emails", "Type", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Emails", "Type", c => c.String(nullable: false));
        }
    }
}
