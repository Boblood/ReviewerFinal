namespace ReviewerFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class images : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "GameImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "GameImage");
        }
    }
}
