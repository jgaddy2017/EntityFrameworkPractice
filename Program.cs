using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPractice
{
    class Program
    {

        #region Notes on set up and basic commands
        //use the nuget command 'install-package EntityFramework'
        //Once, app.config has a <connectionStrings> and your DbContext.cs is created run command 'enable-migrations'

        //to update the database run command 'add-migration nameYourMigrationHere' --this creates the database
        //run command 'update-database' to use your migration to change your sql database

        #endregion

        #region Notes on how to seed data thru Migrations
        /*
         run command 'add-migration nameMigration'
         this will create a migration file in your migrations folders with whatever you named it
         in your migration file, write an insert statement in the UP function. 
         Example:
                 
         public override void Up(){
            Sql("INSERT INTO USERS (name, username, password) VALUES ('John Smith Gaddy', 'jsgaddy', 'password')");
            Sql("INSERT INTO USERS (name, username, password) VALUES ('Quentin Gaddy', 'qman', 'pa$$')");
         }

        End Example
        Once your sql insert statements are written, run the command 'update-database' 
        finished, check your database for seed data
        */
        #endregion
        static void Main(string[] args)
        {
        }
        
    }
}
