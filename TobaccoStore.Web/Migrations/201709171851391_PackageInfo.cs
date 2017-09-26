namespace TobaccoStore.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PackageInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PackageInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Weight = c.Int(nullable: false),
                        ListPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductInfoes", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            DropColumn("dbo.ProductInfoes", "PackageWeight");
            DropColumn("dbo.ProductInfoes", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductInfoes", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProductInfoes", "PackageWeight", c => c.String());
            DropForeignKey("dbo.PackageInfoes", "ProductId", "dbo.ProductInfoes");
            DropIndex("dbo.PackageInfoes", new[] { "ProductId" });
            DropTable("dbo.PackageInfoes");
        }
    }
}
