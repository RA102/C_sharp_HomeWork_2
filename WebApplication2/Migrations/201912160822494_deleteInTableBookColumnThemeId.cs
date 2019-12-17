namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteInTableBookColumnThemeId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "ThemeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "ThemeId", c => c.Int(nullable: false));
        }
    }
}
