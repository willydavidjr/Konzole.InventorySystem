namespace Konzole.InventorySystem.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TruncateTabeUsers : DbMigration
    {
        public override void Up()
        {
            Sql("Truncate Table Users");
            Sql("INSERT INTO USERS(UserName, DateCreated, Password) VALUES ('admin', '06/17/2017', 'WF/UcsnPJIs=')");
        }
        
        public override void Down()
        {
        }
    }
}
