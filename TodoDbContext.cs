using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFrameworkPractice.Models;

namespace EntityFrameworkPractice
{
    #region How to create an entity code model from existing database
    /*
         -Right click project and add new Item
         -Add ADO.NET Entity Data Model and get it a name
         -Then choose Code first from database
         -then click new connection...
         -Fill out connection properties (Server name and connect to a database by select a database name)
         -Entity Data Model Wizard will create a connection string for you
         -click tables and check all tables except _MigrationHistory
    */
    #endregion

    #region

    #endregion

    class TodoDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Importance> Importance { get; set; }
    }
}
