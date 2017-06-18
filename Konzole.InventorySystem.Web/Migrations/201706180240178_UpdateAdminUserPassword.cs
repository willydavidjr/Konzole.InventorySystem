namespace Konzole.InventorySystem.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAdminUserPassword : DbMigration
    {
        public override void Up()
        {
            //Sql("Update Users SET Password = 'WF/UcsnPJIs=' WHERE Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
