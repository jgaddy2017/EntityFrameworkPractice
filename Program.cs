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

        #region Overriding Conventions
            
             //Two types Data Annotations and Fluent API
             /*
              --- Using Data Annotations
              -add using System.ComponentModel.DataAnnotations;
              -name table buy going above the class name and writting [Table("myTableName")]
              -make a field required, go above the property you want to make required and use the annotation [Required]
              -run command 'add-migration migrationName'
              -run command 'update-database'

              -Setting Column name and type annotation, place above class property -> [Column("sName", TypeName = "varchar")]
              -Set property as a primary key -> [Key] and underneath add a second annotation [DatabaseGenerated(DatabaseGeneratedOption.None)]
              -If a property cant be null, use annotation [Required]
              -limiting the length of your string -> [MaxLength(255)]
              -to make sure it is unique -> [Index(IsUnique = true)]

               --how to make a foregin key
               [ForeignKey("AuthorId")]
               public Author Author {get; set;}
             */
        #endregion
        static void Main(string[] args)
        {
        }
        
    }
}
