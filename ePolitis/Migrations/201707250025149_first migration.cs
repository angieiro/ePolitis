namespace ePolitis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citizens",
                c => new
                    {
                        Afm = c.String(nullable: false, maxLength: 128),
                        Amka = c.String(),
                        Ama = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        FathersName = c.String(),
                        MothersName = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.String(),
                        BirthLocation = c.String(),
                        Country = c.String(),
                        Nationality = c.String(),
                        IdNumber = c.String(),
                        PassportNumber = c.String(),
                        AmOaed = c.String(),
                        CardOaed = c.String(),
                        Phone = c.String(),
                        MobilePhone = c.String(),
                        WorkPhone = c.String(),
                        AddressStreet = c.String(),
                        AddressNumber = c.String(),
                        AreaCode = c.String(),
                        County = c.String(),
                        City = c.String(),
                        Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Afm)
                .ForeignKey("dbo.Users", t => t.Email)
                .Index(t => t.Email);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        IsCivilServant = c.Boolean(nullable: false),
                        IsUnemployed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.UnemploymentRequests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        Approved = c.Boolean(nullable: false),
                        FileApplicationPath = c.String(),
                        Afm = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Citizens", t => t.Afm)
                .Index(t => t.Afm);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UnemploymentRequests", "Afm", "dbo.Citizens");
            DropForeignKey("dbo.Citizens", "Email", "dbo.Users");
            DropIndex("dbo.UnemploymentRequests", new[] { "Afm" });
            DropIndex("dbo.Citizens", new[] { "Email" });
            DropTable("dbo.UnemploymentRequests");
            DropTable("dbo.Users");
            DropTable("dbo.Citizens");
        }
    }
}
