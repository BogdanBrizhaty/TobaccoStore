namespace TobaccoStore.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductManufacturer : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TobaccoInfoes", newName: "ProductInfoes");
            CreateTable(
                "dbo.ProductManufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ProductInfoes", "Photo", c => c.Binary());
            AddColumn("dbo.ProductInfoes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.ProductInfoes", "Manufacturer_Id", c => c.Int());
            CreateIndex("dbo.ProductInfoes", "Manufacturer_Id");
            AddForeignKey("dbo.ProductInfoes", "Manufacturer_Id", "dbo.ProductManufacturers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductInfoes", "Manufacturer_Id", "dbo.ProductManufacturers");
            DropIndex("dbo.ProductInfoes", new[] { "Manufacturer_Id" });
            DropColumn("dbo.ProductInfoes", "Manufacturer_Id");
            DropColumn("dbo.ProductInfoes", "Discriminator");
            DropColumn("dbo.ProductInfoes", "Photo");
            DropTable("dbo.ProductManufacturers");
            RenameTable(name: "dbo.ProductInfoes", newName: "TobaccoInfoes");
        }
    }
}
