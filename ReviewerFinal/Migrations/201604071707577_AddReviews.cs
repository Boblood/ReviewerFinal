namespace ReviewerFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReviews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameReviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        RefID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Games", t => t.RefID, cascadeDelete: true)
                .Index(t => t.RefID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameReviews", "RefID", "dbo.Games");
            DropIndex("dbo.GameReviews", new[] { "RefID" });
            DropTable("dbo.GameReviews");
        }
    }
}
