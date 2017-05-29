namespace ePolitis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        FathersName = c.String(),
                        MothersName = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Ama = c.Int(nullable: false),
                        Afm = c.Int(nullable: false),
                        Amka = c.Long(nullable: false),
                        BirthLocation = c.String(),
                        Country = c.String(),
                        Nationality = c.String(),
                        IdNumber = c.String(),
                        PassportNumber = c.String(),
                        Phone = c.String(),
                        MobilePhone = c.String(),
                        WorkPhone = c.String(),
                        AddressStreet = c.String(),
                        AddressNumber = c.Int(nullable: false),
                        Area = c.String(),
                        City = c.String(),
                        AreaCode = c.Int(nullable: false),
                        County = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Unemployeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        FathersName = c.String(),
                        MothersName = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Ama = c.Int(nullable: false),
                        Afm = c.Int(nullable: false),
                        Amka = c.Long(nullable: false),
                        BirthLocation = c.String(),
                        Country = c.String(),
                        Nationality = c.String(),
                        AmOaed = c.Long(nullable: false),
                        CardOaed = c.String(),
                        IdNumber = c.String(),
                        PassportNumber = c.String(),
                        Phone = c.String(),
                        MobilePhone = c.String(),
                        AddressStreet = c.String(),
                        AddressNumber = c.Int(nullable: false),
                        Area = c.String(),
                        City = c.String(),
                        AreaCode = c.Int(nullable: false),
                        County = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Unemployeds");
            DropTable("dbo.Employees");
        }
    }
}
