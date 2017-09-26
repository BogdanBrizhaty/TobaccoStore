namespace TobaccoStore.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PackageInfoWorking : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PackageInfoes", "ProductId", "dbo.ProductInfoes");
            DropIndex("dbo.PackageInfoes", new[] { "ProductId" });
            RenameColumn(table: "dbo.PackageInfoes", name: "ProductId", newName: "ProductInfo_Id");
            AlterColumn("dbo.PackageInfoes", "ProductInfo_Id", c => c.Int());
            CreateIndex("dbo.PackageInfoes", "ProductInfo_Id");
            AddForeignKey("dbo.PackageInfoes", "ProductInfo_Id", "dbo.ProductInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PackageInfoes", "ProductInfo_Id", "dbo.ProductInfoes");
            DropIndex("dbo.PackageInfoes", new[] { "ProductInfo_Id" });
            AlterColumn("dbo.PackageInfoes", "ProductInfo_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.PackageInfoes", name: "ProductInfo_Id", newName: "ProductId");
            CreateIndex("dbo.PackageInfoes", "ProductId");
            AddForeignKey("dbo.PackageInfoes", "ProductId", "dbo.ProductInfoes", "Id", cascadeDelete: true);
        }
    }
}
