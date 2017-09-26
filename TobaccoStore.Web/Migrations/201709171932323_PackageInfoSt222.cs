namespace TobaccoStore.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PackageInfoSt222 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PackageInfoes", "ProductInfo_Id1", "dbo.ProductInfoes");
            DropIndex("dbo.PackageInfoes", new[] { "ProductInfo_Id1" });
            RenameColumn(table: "dbo.PackageInfoes", name: "ProductInfo_Id1", newName: "ProductInfoId");
            AlterColumn("dbo.PackageInfoes", "ProductInfoId", c => c.Int(nullable: false));
            CreateIndex("dbo.PackageInfoes", "ProductInfoId");
            AddForeignKey("dbo.PackageInfoes", "ProductInfoId", "dbo.ProductInfoes", "Id", cascadeDelete: true);
            DropColumn("dbo.PackageInfoes", "ProductInfo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PackageInfoes", "ProductInfo_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.PackageInfoes", "ProductInfoId", "dbo.ProductInfoes");
            DropIndex("dbo.PackageInfoes", new[] { "ProductInfoId" });
            AlterColumn("dbo.PackageInfoes", "ProductInfoId", c => c.Int());
            RenameColumn(table: "dbo.PackageInfoes", name: "ProductInfoId", newName: "ProductInfo_Id1");
            CreateIndex("dbo.PackageInfoes", "ProductInfo_Id1");
            AddForeignKey("dbo.PackageInfoes", "ProductInfo_Id1", "dbo.ProductInfoes", "Id");
        }
    }
}
