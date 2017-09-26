namespace TobaccoStore.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PackageWeightToStringDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductInfoes", "PackageWeight", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductInfoes", "PackageWeight", c => c.Int(nullable: false));
        }
    }
}
