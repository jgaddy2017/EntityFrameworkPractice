using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkPractice.Models;

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
            Console.WriteLine("Hello World");

            #region Pulling Data with linq and extention methods
            /*
            var context = new TodoDbContext();

            //LINQ syntax
            var query =
                from c in context.Users
                where c.Name.Contains("Smith")
                orderby c.Name
                select c;

            foreach (var user in query)
                Console.WriteLine(user.Name);

            //Extension methods
            var users = context.Users.Where(c => c.Name.Contains("quentin")).OrderBy(c => c.Name);

            foreach (var user in users)
                Console.WriteLine(user.Name);
                */
            #endregion


            #region How to get selected info
            /*
             var context = new TodoDbContext();

            var query = 
                from c in context.User
                group c by c.User
                into g
                select g;

                foreach(var group in query){
                    Console.WriteLine(group.Key);
                    
                    foreach(var user in group){
                        Console.WriteLine("\t{0}", user.Name);

                        //--------------how to use count with this--------------------
                        //Console.WriteLine("{0} ({1})", group.Key, group.Count());
                    }
                }
             */
            #endregion


            #region How to do Inner Join, Group Join, Cross Join
            /*
            var context = new TodoDbContext();
            var query =
                from t in context.Todos
                select new { Item = t.item, Name = t.User.Name, Importance = t.importance.importanceName };

            foreach (var item in query) {
                Console.WriteLine("{0} -> {1} -> {2}", item.Item, item.Name, item.Importance);
            }

            Console.WriteLine("-----------------------------------------------------------------");

            //var data = from u in context.Users
             //          join t in context.Todos on u.Id equals t.User into g
             //          select new { User = u.Name, Todo = g.Count() };
             */
            #endregion

            #region LINQ Extension Methods

            //var context = new TodoDbContext();
            /*
            //this returns an IQueryable object
            var data = context.Todos
                .Where(t => t.isDone == true)
                .Select(t => t.item);


            Console.WriteLine(data);
            //how to loop true Iquerable object
            foreach (var todo in data) {
                Console.WriteLine(todo);
            }
            */

            //Using group by
            /*
            var groups = context.Todos.GroupBy(t => t.importance);

            foreach (var group in groups) {
                Console.WriteLine("Key: " + group.Key);
                foreach (var todo in group) {
                    Console.WriteLine("\t" + todo.item);
                }
            }
            */


            //Using Joins
            //not sure how this works
            /*context.Todos.Join(context.Todos, t => t.User, u => u.Id, (todo, user) =>
            {

            });
            */



            #endregion


            #region LINQ extention methods Additional
            /*
            var context = new TodoDbContext();

            var singleData = context.Users.OrderBy(n => n.Name).FirstOrDefault(n => n.Name.Contains("Smith"));
            Console.WriteLine(singleData);
            Console.WriteLine(singleData.Name);

            Console.WriteLine("---------------------    ANY   --------------------------");

            var anyData = context.Todos.Any(t => t.importance.Id == 2);
            Console.WriteLine(anyData);

            Console.WriteLine("--------------------- Counting -----------------------");

            var countData = context.Todos.Count();
            var countTwoData = context.Todos.Where(t => t.importance.Id == 2).Count();

            Console.WriteLine("Count Data is: {0}", countData);
            Console.WriteLine("Count Two Data is: {0}", countTwoData);


            */
            #endregion

            #region Adding Objects

            var context = new TodoDbContext();

            //need to create a reference when to the importance table to use in our insert table
            var todoImportance = context.Importance.Single(a => a.Id == 1);

            //This creates a new user rebecca, if you dont want to create a new record you need to ref the User
            var newTodo = new Todo {
                User = new User { Name = "Rebecca Gaddy", Password = "myPassword", Username = "rhgaddy" },
                createdby = DateTime.Now,
                item = "MUSC Stuff",
                isDone = false,
                importance = todoImportance
            };


            context.Todos.Add(newTodo);
            context.SaveChanges();
            #endregion

            Console.ReadLine();
        }
        
    }
}
