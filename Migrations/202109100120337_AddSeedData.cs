namespace EntityFrameworkPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeedData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO USERS (name, username, password) VALUES ('John Smith Gaddy', 'jsgaddy', 'password')");
            Sql("INSERT INTO USERS (name, username, password) VALUES ('Quentin Gaddy', 'qman', 'pa$$')");
        }
        
        public override void Down()
        {
        }
    }
}
