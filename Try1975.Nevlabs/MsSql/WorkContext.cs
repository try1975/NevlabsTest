using System.Data.Entity;
using Try1975.Nevlabs.Entities;
using Try1975.Nevlabs.Logic;
using Try1975.Nevlabs.Migrations;
using Try1975.Nevlabs.MsSql.Mappings;

namespace Try1975.Nevlabs.MsSql
{
    [DbConfigurationType(typeof(ConfigContext))]
    public class WorkContext : DbContext
    {
        public WorkContext() : base("name=NevLabs")
        {
        }

        public virtual DbSet<PersonEntity> Persons { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new PersonMap(Constants.CreateTableName(nameof(Persons))));
        }
    }

    public class ConfigContext : DbConfiguration
    {
        public ConfigContext()
        {
            SetDatabaseInitializer(new CreateDatabaseIfNotExists<WorkContext>());
            SetDatabaseInitializer(new MigrateDatabaseToLatestVersion<WorkContext, Configuration>());
        }
    }
}