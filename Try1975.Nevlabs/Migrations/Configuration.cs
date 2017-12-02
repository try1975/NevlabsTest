using System.Data.Entity.Migrations;
using Try1975.Nevlabs.MsSql;

namespace Try1975.Nevlabs.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WorkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WorkContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}