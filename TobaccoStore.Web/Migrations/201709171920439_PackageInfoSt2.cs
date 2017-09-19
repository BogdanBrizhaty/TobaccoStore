namespace TobaccoStore.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PackageInfoSt2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "ListPrice", c => c.Int(nullable: false));
            AddColumn("dbo.OrderItems", "PackageWeight", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderItems", "PackageWeight");
            DropColumn("dbo.OrderItems", "ListPrice");
        }
    }
}
