namespace ePolitis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UnemploymentRequests", "Afm", c => c.Int(nullable: false));
            CreateIndex("dbo.UnemploymentRequests", "Afm");
            AddForeignKey("dbo.UnemploymentRequests", "Afm", "dbo.Employees", "Afm", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UnemploymentRequests", "Afm", "dbo.Employees");
            DropIndex("dbo.UnemploymentRequests", new[] { "Afm" });
            DropColumn("dbo.UnemploymentRequests", "Afm");
        }
    }
}
