namespace Konzole.InventorySystem.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableUsers1 : DbMigration
    {
        public override void Up()
        {
            Sql("Update Users SET UserName = 'admin' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
