namespace TobaccoStore.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tobaccoinforeplaced : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductInfoes", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductInfoes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
