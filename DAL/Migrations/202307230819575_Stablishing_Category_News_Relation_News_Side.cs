namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stablishing_Category_News_Relation_News_Side : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.News", "Category_Category_ID", "dbo.Categories");
            DropIndex("dbo.News", new[] { "Category_Category_ID" });
            RenameColumn(table: "dbo.News", name: "Category_Category_ID", newName: "Category_ID");
            AlterColumn("dbo.News", "Category_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.News", "Category_ID");
            AddForeignKey("dbo.News", "Category_ID", "dbo.Categories", "Category_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "Category_ID", "dbo.Categories");
            DropIndex("dbo.News", new[] { "Category_ID" });
            AlterColumn("dbo.News", "Category_ID", c => c.Int());
            RenameColumn(table: "dbo.News", name: "Category_ID", newName: "Category_Category_ID");
            CreateIndex("dbo.News", "Category_Category_ID");
            AddForeignKey("dbo.News", "Category_Category_ID", "dbo.Categories", "Category_ID");
        }
    }
}
