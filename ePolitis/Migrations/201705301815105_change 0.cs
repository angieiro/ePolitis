namespace ePolitis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change0 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "AfmEmpl", "dbo.Employees");
            DropForeignKey("dbo.Users", "AfmUn", "dbo.Unemployeds");
            DropIndex("dbo.Users", new[] { "AfmUn" });
            DropIndex("dbo.Users", new[] { "AfmEmpl" });
            DropColumn("dbo.Users", "AfmUn");
            DropColumn("dbo.Users", "AfmEmpl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "AfmEmpl", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "AfmUn", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "AfmEmpl");
            CreateIndex("dbo.Users", "AfmUn");
            AddForeignKey("dbo.Users", "AfmUn", "dbo.Unemployeds", "Afm", cascadeDelete: true);
            AddForeignKey("dbo.Users", "AfmEmpl", "dbo.Employees", "Afm", cascadeDelete: true);
        }
    }
}
