using System.Data.Entity.Migrations;

namespace Database.Migrations
{
    /// <summary>
    /// add-migration "comment without spaces"
    /// update-database
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<PaperWorkerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PaperWorkerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}