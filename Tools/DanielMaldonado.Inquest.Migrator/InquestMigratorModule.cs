using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using DanielMaldonado.Inquest.EntityFramework;

namespace DanielMaldonado.Inquest.Migrator
{
    [DependsOn(typeof(InquestDataModule))]
    public class InquestMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<InquestDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}