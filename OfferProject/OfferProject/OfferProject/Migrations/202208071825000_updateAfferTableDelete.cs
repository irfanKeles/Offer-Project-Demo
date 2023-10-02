namespace OfferProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAfferTableDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offers", "delete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offers", "delete");
        }
    }
}
