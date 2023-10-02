namespace OfferProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredAdd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Offers", "Currency_ID", "dbo.Currencies");
            DropIndex("dbo.Offers", new[] { "Currency_ID" });
            AlterColumn("dbo.Offers", "Currency_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Offers", "Currency_ID");
            AddForeignKey("dbo.Offers", "Currency_ID", "dbo.Currencies", "Currency_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "Currency_ID", "dbo.Currencies");
            DropIndex("dbo.Offers", new[] { "Currency_ID" });
            AlterColumn("dbo.Offers", "Currency_ID", c => c.Int());
            CreateIndex("dbo.Offers", "Currency_ID");
            AddForeignKey("dbo.Offers", "Currency_ID", "dbo.Currencies", "Currency_ID");
        }
    }
}
