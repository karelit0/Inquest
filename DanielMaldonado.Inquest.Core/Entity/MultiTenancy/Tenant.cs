using Abp.MultiTenancy;
using DanielMaldonado.Inquest.Users;

namespace DanielMaldonado.Inquest.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}