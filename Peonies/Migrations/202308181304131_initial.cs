namespace Peonies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Client_ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Clients", t => t.Client_ClientId)
                .Index(t => t.Client_ClientId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailsID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        FullPrice = c.Int(nullable: false),
                        Order_OrderID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderDetailsID)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID)
                .Index(t => t.Order_OrderID);
            
            CreateTable(
                "dbo.Peonies",
                c => new
                    {
                        PeonyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type_PeonyTypeId = c.Int(),
                        Variety_VarietyId = c.Int(),
                        OrderDetails_OrderDetailsID = c.Int(),
                    })
                .PrimaryKey(t => t.PeonyId)
                .ForeignKey("dbo.PeonyTypes", t => t.Type_PeonyTypeId)
                .ForeignKey("dbo.Varieties", t => t.Variety_VarietyId)
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetails_OrderDetailsID)
                .Index(t => t.Type_PeonyTypeId)
                .Index(t => t.Variety_VarietyId)
                .Index(t => t.OrderDetails_OrderDetailsID);
            
            CreateTable(
                "dbo.PeonyTypes",
                c => new
                    {
                        PeonyTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PeonyTypeId);
            
            CreateTable(
                "dbo.Varieties",
                c => new
                    {
                        VarietyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Color = c.String(),
                        Height = c.Int(nullable: false),
                        Diameter = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VarietyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Peonies", "OrderDetails_OrderDetailsID", "dbo.OrderDetails");
            DropForeignKey("dbo.Peonies", "Variety_VarietyId", "dbo.Varieties");
            DropForeignKey("dbo.Peonies", "Type_PeonyTypeId", "dbo.PeonyTypes");
            DropForeignKey("dbo.Orders", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.Peonies", new[] { "OrderDetails_OrderDetailsID" });
            DropIndex("dbo.Peonies", new[] { "Variety_VarietyId" });
            DropIndex("dbo.Peonies", new[] { "Type_PeonyTypeId" });
            DropIndex("dbo.OrderDetails", new[] { "Order_OrderID" });
            DropIndex("dbo.Orders", new[] { "Client_ClientId" });
            DropTable("dbo.Varieties");
            DropTable("dbo.PeonyTypes");
            DropTable("dbo.Peonies");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Clients");
        }
    }
}
