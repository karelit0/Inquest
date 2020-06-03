using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using DanielMaldonado.Inquest.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace DanielMaldonado.Inquest.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<Inquest.EntityFramework.InquestDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Inquest";
        }

        protected override void Seed(Inquest.EntityFramework.InquestDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }
            new DefaultLocationCreator(context).Create();
            new DefaultSurveyCreator(context).Create();

            context.SaveChanges();
        }
    }
}
