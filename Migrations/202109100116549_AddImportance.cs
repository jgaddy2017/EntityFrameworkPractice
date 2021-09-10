namespace EntityFrameworkPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImportance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Importances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        importanceName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Todoes", "importance_Id", c => c.Int());
            CreateIndex("dbo.Todoes", "importance_Id");
            AddForeignKey("dbo.Todoes", "importance_Id", "dbo.Importances", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Todoes", "importance_Id", "dbo.Importances");
            DropIndex("dbo.Todoes", new[] { "importance_Id" });
            DropColumn("dbo.Todoes", "importance_Id");
            DropTable("dbo.Importances");
        }
    }
}
