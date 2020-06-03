using System.Linq;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using DanielMaldonado.Inquest.Authorization;
using DanielMaldonado.Inquest.Authorization.Roles;
using DanielMaldonado.Inquest.EntityFramework;
using DanielMaldonado.Inquest.Users;
using Microsoft.AspNet.Identity;

namespace DanielMaldonado.Inquest.Migrations.SeedData
{
    public class TenantRoleAndUserBuilder
    {
        private readonly InquestDbContext _context;
        private readonly int _tenantId;

        public TenantRoleAndUserBuilder(InquestDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            //Admin role

            var adminRole = _context.Roles.FirstOrDefault(r => r.TenantId == _tenantId && r.Name == StaticRoleNames.Tenants.Admin);
            if (adminRole == null)
            {
                adminRole = _context.Roles.Add(new Role(_tenantId, StaticRoleNames.Tenants.Admin, StaticRoleNames.Tenants.Admin) { IsStatic = true });
                _context.SaveChanges();

                //Grant all permissions to admin role
                var permissions = PermissionFinder
                    .GetAllPermissions(new InquestAuthorizationProvider())
                    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant))
                    .ToList();

                foreach (var permission in permissions)
                {
                    _context.Permissions.Add(
                        new RolePermissionSetting
                        {
                            TenantId = _tenantId,
                            Name = permission.Name,
                            IsGranted = true,
                            RoleId = adminRole.Id
                        });
                }

                _context.SaveChanges();
            }

            //admin user

            var adminUser = _context.Users.FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == User.AdminUserName);
            if (adminUser == null)
            {
                adminUser = User.CreateTenantAdminUser(_tenantId, "admin@defaulttenant.com", "123qwe");
                adminUser.IsEmailConfirmed = true;
                adminUser.IsActive = true;

                _context.Users.Add(adminUser);
                _context.SaveChanges();

                //Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(_tenantId, adminUser.Id, adminRole.Id));
                _context.SaveChanges();
            }

            var guestUser = _context.Users.FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == "Guest");
            if (guestUser == null)
            {
                guestUser = new User();
                guestUser.TenantId = _tenantId;
                guestUser.Name = "Guest";
                guestUser.Surname = "Guest";
                guestUser.UserName = "Guest";
                guestUser.EmailAddress = "guest.user@guest.com";
                guestUser.Password = new PasswordHasher().HashPassword("Gu3stUs3rP@ssw0rd");
                guestUser.IsEmailConfirmed = true;
                guestUser.IsActive = true;

                _context.Users.Add(guestUser);
                _context.SaveChanges();
            }
        }
    }
}