namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedInformationMethodAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Information", "Bio", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Information", "Bio", c => c.String(nullable: false));
        }
    }
}
