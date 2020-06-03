using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using KinareApp.NetFramework.ExpressionBuilder;
using DanielMaldonado.Inquest.Location.Dto;
using DanielMaldonado.Inquest.Entity.Location;

namespace DanielMaldonado.Inquest
{
    [DependsOn(typeof(InquestCoreModule), typeof(AbpAutoMapperModule))]
    public class InquestApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()
                mapper.CreateMap<BranchOfficeDto, BranchOffice>()
                 .ForMember(a => a.City, b => b.ResolveUsing(c => new City { Id = c.CityId }));
            });
        }

        public override void Initialize()
        {
            IocManager.Register<ILinqExpressionBuilder, LinqExpressionBuilder>(Abp.Dependency.DependencyLifeStyle.Transient);
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
