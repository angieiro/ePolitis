namespace ePolitis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change5 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "Afm", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Employees", "Afm");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "Afm", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employees", "Afm");
        }
    }
}
