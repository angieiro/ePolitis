namespace ePolitis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "FileApplicationPath", c => c.String());
            DropColumn("dbo.Unemployeds", "FileApplicationPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Unemployeds", "FileApplicationPath", c => c.String());
            DropColumn("dbo.Employees", "FileApplicationPath");
        }
    }
}
