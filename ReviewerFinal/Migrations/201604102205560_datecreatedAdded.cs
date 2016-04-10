namespace ReviewerFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datecreatedAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameReviews", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameReviews", "DateCreated");
        }
    }
}
