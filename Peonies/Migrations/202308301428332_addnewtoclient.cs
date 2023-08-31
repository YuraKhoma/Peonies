namespace Peonies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewtoclient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.Orders", new[] { "Client_ClientId" });
            AddColumn("dbo.Orders", "Client_ClientId1", c => c.Int());
            AlterColumn("dbo.Orders", "Client_ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Client_ClientId1");
            AddForeignKey("dbo.Orders", "Client_ClientId1", "dbo.Clients", "ClientId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Client_ClientId1", "dbo.Clients");
            DropIndex("dbo.Orders", new[] { "Client_ClientId1" });
            AlterColumn("dbo.Orders", "Client_ClientId", c => c.Int());
            DropColumn("dbo.Orders", "Client_ClientId1");
            CreateIndex("dbo.Orders", "Client_ClientId");
            AddForeignKey("dbo.Orders", "Client_ClientId", "dbo.Clients", "ClientId");
        }
    }
}
