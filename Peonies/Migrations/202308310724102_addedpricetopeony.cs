namespace Peonies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpricetopeony : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Peonies", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Peonies", "Price");
        }
    }
}
