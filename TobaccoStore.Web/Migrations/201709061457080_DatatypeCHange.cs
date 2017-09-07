namespace TobaccoStore.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatatypeCHange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetails", "MobilePhone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "MobilePhone", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
