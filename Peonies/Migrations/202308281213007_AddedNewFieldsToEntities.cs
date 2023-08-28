namespace Peonies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewFieldsToEntities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Number", c => c.String());
            AddColumn("dbo.Orders", "CreatedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CreatedOn");
            DropColumn("dbo.Orders", "Number");
        }
    }
}
