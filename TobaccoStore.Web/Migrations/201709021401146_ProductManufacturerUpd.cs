namespace TobaccoStore.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductManufacturerUpd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductInfoes", "Manufacturer_Id", "dbo.ProductManufacturers");
            DropIndex("dbo.ProductInfoes", new[] { "Manufacturer_Id" });
            AlterColumn("dbo.ProductInfoes", "Manufacturer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductInfoes", "Manufacturer_Id");
            AddForeignKey("dbo.ProductInfoes", "Manufacturer_Id", "dbo.ProductManufacturers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductInfoes", "Manufacturer_Id", "dbo.ProductManufacturers");
            DropIndex("dbo.ProductInfoes", new[] { "Manufacturer_Id" });
            AlterColumn("dbo.ProductInfoes", "Manufacturer_Id", c => c.Int());
            CreateIndex("dbo.ProductInfoes", "Manufacturer_Id");
            AddForeignKey("dbo.ProductInfoes", "Manufacturer_Id", "dbo.ProductManufacturers", "Id");
        }
    }
}
