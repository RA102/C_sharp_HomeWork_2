namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteInTableBookColumnPublishDate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "PublishDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "PublishDate", c => c.DateTime(nullable: false));
        }
    }
}
