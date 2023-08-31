namespace Peonies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewtoclientaaa : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "Client_ClientId1" });
            DropColumn("dbo.Orders", "Client_ClientId");
            RenameColumn(table: "dbo.Orders", name: "Client_ClientId1", newName: "Client_ClientId");
            AlterColumn("dbo.Orders", "Client_ClientId", c => c.Int());
            CreateIndex("dbo.Orders", "Client_ClientId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", new[] { "Client_ClientId" });
            AlterColumn("dbo.Orders", "Client_ClientId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Orders", name: "Client_ClientId", newName: "Client_ClientId1");
            AddColumn("dbo.Orders", "Client_ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Client_ClientId1");
        }
    }
}
