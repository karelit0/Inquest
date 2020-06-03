using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using DanielMaldonado.Inquest.EntityFramework;

namespace DanielMaldonado.Inquest
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(InquestCoreModule))]
    public class InquestDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<InquestDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
