namespace ePolitis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Email", c => c.String(maxLength: 128));
            AddColumn("dbo.Unemployeds", "Email", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "Email");
            CreateIndex("dbo.Unemployeds", "Email");
            AddForeignKey("dbo.Employees", "Email", "dbo.Users", "Email");
            AddForeignKey("dbo.Unemployeds", "Email", "dbo.Users", "Email");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Unemployeds", "Email", "dbo.Users");
            DropForeignKey("dbo.Employees", "Email", "dbo.Users");
            DropIndex("dbo.Unemployeds", new[] { "Email" });
            DropIndex("dbo.Employees", new[] { "Email" });
            DropColumn("dbo.Unemployeds", "Email");
            DropColumn("dbo.Employees", "Email");
        }
    }
}
