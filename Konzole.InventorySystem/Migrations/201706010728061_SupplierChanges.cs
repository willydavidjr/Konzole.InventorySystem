namespace Konzole.InventorySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupplierChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("IV.Supplier", "SupplierName", c => c.String());
            AddColumn("IV.Supplier", "EWTId", c => c.Int(nullable: false));
            AddColumn("IV.Supplier", "VATtypeId", c => c.Int(nullable: false));
            AddColumn("IV.Supplier", "Terms", c => c.Int(nullable: false));
            AddColumn("IV.Supplier", "Recuser", c => c.String());
            AddColumn("IV.Supplier", "Recdate", c => c.DateTime());
            AddColumn("IV.Supplier", "Moduser", c => c.Int(nullable: false));
            AddColumn("IV.Supplier", "ModDate", c => c.DateTime());
            AddColumn("IV.Supplier", "Taxcode", c => c.String());
            AddColumn("IV.Supplier", "Status", c => c.Int(nullable: false));
            DropColumn("IV.Supplier", "Name");
        }
        
        public override void Down()
        {
            AddColumn("IV.Supplier", "Name", c => c.String());
            DropColumn("IV.Supplier", "Status");
            DropColumn("IV.Supplier", "Taxcode");
            DropColumn("IV.Supplier", "ModDate");
            DropColumn("IV.Supplier", "Moduser");
            DropColumn("IV.Supplier", "Recdate");
            DropColumn("IV.Supplier", "Recuser");
            DropColumn("IV.Supplier", "Terms");
            DropColumn("IV.Supplier", "VATtypeId");
            DropColumn("IV.Supplier", "EWTId");
            DropColumn("IV.Supplier", "SupplierName");
        }
    }
}
