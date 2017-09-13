namespace TobaccoStore.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TokenToOrderDetailsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "UserAccessToken", c => c.String());
            AddColumn("dbo.OrderDetails", "UserAccessPermition", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "UserAccessPermition");
            DropColumn("dbo.OrderDetails", "UserAccessToken");
        }
    }
}
