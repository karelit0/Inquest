using Abp.Authorization;
using DanielMaldonado.Inquest.Authorization.Roles;
using DanielMaldonado.Inquest.MultiTenancy;
using DanielMaldonado.Inquest.Users;

namespace DanielMaldonado.Inquest.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
