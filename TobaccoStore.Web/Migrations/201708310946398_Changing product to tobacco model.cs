namespace TobaccoStore.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changingproducttotobaccomodel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductInfoes", newName: "TobaccoInfoes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TobaccoInfoes", newName: "ProductInfoes");
        }
    }
}
