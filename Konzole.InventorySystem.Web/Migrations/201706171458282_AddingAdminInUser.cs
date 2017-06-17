namespace Konzole.InventorySystem.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAdminInUser : DbMigration
    {
        public override void Up()
        {
            //Sql("INSERT INTO USERS(UserName, DateCreated, Password) VALUES ('admin', '06/17/2017', 'admin')");
        }
        
        public override void Down()
        {
        }
    }
}
