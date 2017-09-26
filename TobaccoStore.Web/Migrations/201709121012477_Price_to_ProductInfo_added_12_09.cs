namespace TobaccoStore.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Price_to_ProductInfo_added_12_09 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductInfoes", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductInfoes", "Price");
        }
    }
}
