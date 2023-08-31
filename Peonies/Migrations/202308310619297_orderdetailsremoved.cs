namespace Peonies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderdetailsremoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Peonies", "OrderDetails_OrderDetailsID", "dbo.OrderDetails");
            DropForeignKey("dbo.OrderDetails", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "Order_OrderID" });
            DropIndex("dbo.Peonies", new[] { "OrderDetails_OrderDetailsID" });
            AddColumn("dbo.Orders", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "FullPrice", c => c.Int(nullable: false));
            AddColumn("dbo.Peonies", "Order_OrderID", c => c.Int());
            CreateIndex("dbo.Peonies", "Order_OrderID");
            AddForeignKey("dbo.Peonies", "Order_OrderID", "dbo.Orders", "OrderID");
            DropColumn("dbo.Peonies", "OrderDetails_OrderDetailsID");
            DropTable("dbo.OrderDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailsID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        FullPrice = c.Int(nullable: false),
                        Order_OrderID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderDetailsID);
            
            AddColumn("dbo.Peonies", "OrderDetails_OrderDetailsID", c => c.Int());
            DropForeignKey("dbo.Peonies", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.Peonies", new[] { "Order_OrderID" });
            DropColumn("dbo.Peonies", "Order_OrderID");
            DropColumn("dbo.Orders", "FullPrice");
            DropColumn("dbo.Orders", "Quantity");
            CreateIndex("dbo.Peonies", "OrderDetails_OrderDetailsID");
            CreateIndex("dbo.OrderDetails", "Order_OrderID");
            AddForeignKey("dbo.OrderDetails", "Order_OrderID", "dbo.Orders", "OrderID");
            AddForeignKey("dbo.Peonies", "OrderDetails_OrderDetailsID", "dbo.OrderDetails", "OrderDetailsID");
        }
    }
}
