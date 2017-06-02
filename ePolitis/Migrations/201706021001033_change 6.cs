namespace ePolitis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change6 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Unemployeds");
            AlterColumn("dbo.Unemployeds", "Afm", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Unemployeds", "Afm");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Unemployeds");
            AlterColumn("dbo.Unemployeds", "Afm", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Unemployeds", "Afm");
        }
    }
}
