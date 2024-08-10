namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stablishing_Category_News_Relation_Cateory_Side : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "Category_Category_ID", c => c.Int());
            CreateIndex("dbo.News", "Category_Category_ID");
            AddForeignKey("dbo.News", "Category_Category_ID", "dbo.Categories", "Category_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "Category_Category_ID", "dbo.Categories");
            DropIndex("dbo.News", new[] { "Category_Category_ID" });
            DropColumn("dbo.News", "Category_Category_ID");
        }
    }
}
