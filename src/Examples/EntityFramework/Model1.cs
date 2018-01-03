namespace Examples.EntityFramework
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EntityFramework.SqlServer.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public Model1()
            : base("name=ConnectionString")
        {

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<GroupEntity> Groups { get; set; }
        public virtual DbSet<ItemEntity> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties()
                    .Where(p => p.Name == "Id")
                    .Configure(p => p.IsKey());

            modelBuilder.Entity<GroupEntity>()
                .ToTable("GroupEntity")
                .Property(en => en.Name);

            modelBuilder.Entity<ItemEntity>()
                .ToTable("ItemEntity")
                .Property(en => en.Name);

            modelBuilder.Entity<ItemEntity>()
                .HasOptional(en => en.Group)
                .WithMany(en => en.Items)
                .Map(m => m.MapKey("GroupId"));
        }
    }
}