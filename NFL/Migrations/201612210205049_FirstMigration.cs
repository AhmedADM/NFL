namespace NFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        cityId = c.Int(nullable: false),
                        playerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.cityId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.playerId, cascadeDelete: true)
                .Index(t => t.cityId)
                .Index(t => t.playerId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ZipCode = c.Int(nullable: false),
                        State = c.String(nullable: false),
                        StateName = c.String(),
                        City = c.String(nullable: false),
                        lat = c.Single(nullable: false),
                        lng = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        playerId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.playerId);
            
            CreateTable(
                "dbo.ContactInformations",
                c => new
                    {
                        playerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.playerId)
                .ForeignKey("dbo.Players", t => t.playerId)
                .Index(t => t.playerId);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        email = c.String(),
                        Type = c.String(),
                        contactInformationId = c.Int(nullable: false),
                        contactInformation_playerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactInformations", t => t.contactInformation_playerId)
                .Index(t => t.contactInformation_playerId);
            
            CreateTable(
                "dbo.Faxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Type = c.String(),
                        contactInformationId = c.Int(nullable: false),
                        contactInformation_playerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactInformations", t => t.contactInformation_playerId)
                .Index(t => t.contactInformation_playerId);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Type = c.String(),
                        contactInformationId = c.Int(nullable: false),
                        contactInformation_playerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactInformations", t => t.contactInformation_playerId)
                .Index(t => t.contactInformation_playerId);
            
            CreateTable(
                "dbo.Information",
                c => new
                    {
                        informationId = c.Int(nullable: false),
                        Bio = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.informationId)
                .ForeignKey("dbo.Players", t => t.informationId)
                .Index(t => t.informationId);
            
            CreateTable(
                "dbo.Education_History",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Degree = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        informationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Information", t => t.informationId, cascadeDelete: true)
                .Index(t => t.informationId);
            
            CreateTable(
                "dbo.Measurments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tall = c.String(nullable: false),
                        weight = c.Double(nullable: false),
                        ArmLength = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        Position = c.String(),
                        mainPositionId = c.Int(nullable: false),
                        informationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Information", t => t.informationId, cascadeDelete: true)
                .ForeignKey("dbo.MainPositions", t => t.mainPositionId, cascadeDelete: true)
                .Index(t => t.mainPositionId)
                .Index(t => t.informationId);
            
            CreateTable(
                "dbo.MainPositions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Abbriviation = c.String(),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonalInformations",
                c => new
                    {
                        playerId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.playerId)
                .ForeignKey("dbo.Players", t => t.playerId)
                .Index(t => t.playerId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PersonalInformations", "playerId", "dbo.Players");
            DropForeignKey("dbo.Information", "informationId", "dbo.Players");
            DropForeignKey("dbo.Measurments", "mainPositionId", "dbo.MainPositions");
            DropForeignKey("dbo.Measurments", "informationId", "dbo.Information");
            DropForeignKey("dbo.Education_History", "informationId", "dbo.Information");
            DropForeignKey("dbo.ContactInformations", "playerId", "dbo.Players");
            DropForeignKey("dbo.Phones", "contactInformation_playerId", "dbo.ContactInformations");
            DropForeignKey("dbo.Faxes", "contactInformation_playerId", "dbo.ContactInformations");
            DropForeignKey("dbo.Emails", "contactInformation_playerId", "dbo.ContactInformations");
            DropForeignKey("dbo.Addresses", "playerId", "dbo.Players");
            DropForeignKey("dbo.Addresses", "cityId", "dbo.Cities");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PersonalInformations", new[] { "playerId" });
            DropIndex("dbo.Measurments", new[] { "informationId" });
            DropIndex("dbo.Measurments", new[] { "mainPositionId" });
            DropIndex("dbo.Education_History", new[] { "informationId" });
            DropIndex("dbo.Information", new[] { "informationId" });
            DropIndex("dbo.Phones", new[] { "contactInformation_playerId" });
            DropIndex("dbo.Faxes", new[] { "contactInformation_playerId" });
            DropIndex("dbo.Emails", new[] { "contactInformation_playerId" });
            DropIndex("dbo.ContactInformations", new[] { "playerId" });
            DropIndex("dbo.Addresses", new[] { "playerId" });
            DropIndex("dbo.Addresses", new[] { "cityId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PersonalInformations");
            DropTable("dbo.MainPositions");
            DropTable("dbo.Measurments");
            DropTable("dbo.Education_History");
            DropTable("dbo.Information");
            DropTable("dbo.Phones");
            DropTable("dbo.Faxes");
            DropTable("dbo.Emails");
            DropTable("dbo.ContactInformations");
            DropTable("dbo.Players");
            DropTable("dbo.Cities");
            DropTable("dbo.Addresses");
        }
    }
}
