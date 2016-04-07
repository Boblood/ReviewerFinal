namespace ReviewerFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReviews2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NumberOfGamesPlayed", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "CurrentPlayerLevel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CurrentPlayerLevel");
            DropColumn("dbo.AspNetUsers", "NumberOfGamesPlayed");
        }
    }
}
