namespace TobaccoStore.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscountAndOrderEntities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductInfoes", "PackageWeight", c => c.Int(nullable: false));
            DropColumn("dbo.ProductInfoes", "Discount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductInfoes", "Discount", c => c.Byte(nullable: false));
            DropColumn("dbo.ProductInfoes", "PackageWeight");
        }
    }
}
