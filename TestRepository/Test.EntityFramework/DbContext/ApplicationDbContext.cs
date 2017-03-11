using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web.Configuration;
using Test.Core.Model;

namespace Test.EntityFramework.DbContext
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base(WebConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString, false)
        {
            Configuration.LazyLoadingEnabled = false;
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

         public DbSet<Student> Students { get; set; }
       

    }

    //public class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    //{
    //    public Configuration()
    //    {
    //        AutomaticMigrationsEnabled = false;
    //        AutomaticMigrationDataLossAllowed = false;
    //    }

    //    protected override void Seed(ApplicationDbContext context)
    //    {
    //        base.Seed(context);
    //    }

    //}

}
