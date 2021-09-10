namespace EntityFrameworkPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class two : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "User_Id", c => c.Int());
            CreateIndex("dbo.Todoes", "User_Id");
            AddForeignKey("dbo.Todoes", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Todoes", "User_Id", "dbo.Users");
            DropIndex("dbo.Todoes", new[] { "User_Id" });
            DropColumn("dbo.Todoes", "User_Id");
        }
    }
}
