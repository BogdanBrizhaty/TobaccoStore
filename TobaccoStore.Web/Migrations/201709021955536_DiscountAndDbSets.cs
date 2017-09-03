namespace TobaccoStore.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscountAndDbSets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Cashback = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductInfoes", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        FullName = c.String(),
                        DelieveryAddress = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MobilePhone = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Email = c.String(),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderDetails", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.ProductInfoes", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.ProductInfoes");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.OrderDetails");
            DropForeignKey("dbo.Discounts", "ProductId", "dbo.ProductInfoes");
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.Discounts", new[] { "ProductId" });
            DropTable("dbo.OrderItems");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Discounts");
        }
    }
}
