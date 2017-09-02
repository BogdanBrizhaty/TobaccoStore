namespace TobaccoStore.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.TobaccoInfoes", newName: "dbo.ProductInfoes");
        }

        public override void Down()
        {
            //RenameTable(name: "dbo.ProductInfoes", newName: "dbo.TobaccoInfoes");
        }
    }
}
