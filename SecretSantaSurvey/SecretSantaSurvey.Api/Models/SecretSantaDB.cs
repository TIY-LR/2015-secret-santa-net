namespace SecretSantaSurvey.API.Models
{
    using Api.Models;
    using Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SecretSantaDB : DbContext
    {
        // Your context has been configured to use a 'SecretSantaDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SecretSantaSurvey.API.Models.SecretSantaDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SecretSantaDB' 
        // connection string in the application configuration file.
        public SecretSantaDB()
            : base("name=SecretSantaDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SecretSantaDB, Configuration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<SecretSantaSurvey.Api.Models.Survey> Surveys { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}