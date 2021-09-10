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

        #region how to seed data thru config file
            /*
             -go to your configuration.cs 
             -in the override void Seed method write your seed statement
             Example
                context.yourTable/modelName.AddOrUpdate(a => a.Name,
                    new Author
                    {
                        Name = "Author 1",
                        Courses = new Collection<Course>(){
                            new Course() { Name = "Course for Author 1", Description = "Description" }
                        }
                    });
             */
        #endregion
        static void Main(string[] args)
        {
        }
        
    }
}
