namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConstructEmployeeRelations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "contactInformation_Id", c => c.Int());
            AddColumn("dbo.Employees", "personalInformation_Id", c => c.Int());
            AddColumn("dbo.Experiences", "Employee_Id", c => c.Int());
            CreateIndex("dbo.Employees", "contactInformation_Id");
            CreateIndex("dbo.Employees", "personalInformation_Id");
            CreateIndex("dbo.Experiences", "Employee_Id");
            AddForeignKey("dbo.Employees", "contactInformation_Id", "dbo.ContactInformations", "Id");
            AddForeignKey("dbo.Employees", "personalInformation_Id", "dbo.PersonalInformations", "Id");
            AddForeignKey("dbo.Experiences", "Employee_Id", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Experiences", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "personalInformation_Id", "dbo.PersonalInformations");
            DropForeignKey("dbo.Employees", "contactInformation_Id", "dbo.ContactInformations");
            DropIndex("dbo.Experiences", new[] { "Employee_Id" });
            DropIndex("dbo.Employees", new[] { "personalInformation_Id" });
            DropIndex("dbo.Employees", new[] { "contactInformation_Id" });
            DropColumn("dbo.Experiences", "Employee_Id");
            DropColumn("dbo.Employees", "personalInformation_Id");
            DropColumn("dbo.Employees", "contactInformation_Id");
        }
    }
}
