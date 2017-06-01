namespace ePolitis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UnemploymentRequests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.RequestId);
            
            AddColumn("dbo.Employees", "UnemploymentRequest_RequestId", c => c.Int());
            CreateIndex("dbo.Employees", "UnemploymentRequest_RequestId");
            AddForeignKey("dbo.Employees", "UnemploymentRequest_RequestId", "dbo.UnemploymentRequests", "RequestId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "UnemploymentRequest_RequestId", "dbo.UnemploymentRequests");
            DropIndex("dbo.Employees", new[] { "UnemploymentRequest_RequestId" });
            DropColumn("dbo.Employees", "UnemploymentRequest_RequestId");
            DropTable("dbo.UnemploymentRequests");
        }
    }
}
