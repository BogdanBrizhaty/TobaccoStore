namespace TobaccoStore.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PackageInfoSt22 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PackageInfoes", "ProductInfo_Id", "dbo.ProductInfoes");
            DropIndex("dbo.PackageInfoes", new[] { "ProductInfo_Id" });
            AddColumn("dbo.PackageInfoes", "ProductInfo_Id1", c => c.Int());
            AlterColumn("dbo.PackageInfoes", "ProductInfo_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.PackageInfoes", "ProductInfo_Id1");
            AddForeignKey("dbo.PackageInfoes", "ProductInfo_Id1", "dbo.ProductInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PackageInfoes", "ProductInfo_Id1", "dbo.ProductInfoes");
            DropIndex("dbo.PackageInfoes", new[] { "ProductInfo_Id1" });
            AlterColumn("dbo.PackageInfoes", "ProductInfo_Id", c => c.Int());
            DropColumn("dbo.PackageInfoes", "ProductInfo_Id1");
            CreateIndex("dbo.PackageInfoes", "ProductInfo_Id");
            AddForeignKey("dbo.PackageInfoes", "ProductInfo_Id", "dbo.ProductInfoes", "Id");
        }
    }
}
