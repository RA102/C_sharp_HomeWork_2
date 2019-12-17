namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editTableAuthorAddForeingKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Authors", "CountryId");
            AddForeignKey("dbo.Authors", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Authors", "CountryId", "dbo.Countries");
            DropIndex("dbo.Authors", new[] { "CountryId" });
        }
    }
}
