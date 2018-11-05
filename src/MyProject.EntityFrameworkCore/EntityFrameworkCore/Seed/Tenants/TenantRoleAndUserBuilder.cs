using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using MyProject.Authorization;
using MyProject.Authorization.Roles;
using MyProject.Authorization.Users;

namespace MyProject.EntityFrameworkCore.Seed.Tenants
{
    public class TenantRoleAndUserBuilder
    {
        private readonly MyProjectDbContext _context;
        private readonly int _tenantId;

        public TenantRoleAndUserBuilder(MyProjectDbContext context, int tenantId)
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
            // Admin role

            var adminRole = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == _tenantId && r.Name == StaticRoleNames.Tenants.Admin);
            if (adminRole == null)
            {
                adminRole = _context.Roles.Add(new Role(_tenantId, StaticRoleNames.Tenants.Admin, StaticRoleNames.Tenants.Admin) { IsStatic = true }).Entity;
                _context.SaveChanges();
            }

            var guidlineAdmin = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == _tenantId && r.Name == "GLAdmin");
            if (guidlineAdmin == null)
            {
                guidlineAdmin = _context.Roles.Add(new Role(_tenantId, "GLAdmin", "Guideline Administrator") { IsStatic = true }).Entity;
                _context.SaveChanges();
            }

            var drafter = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == _tenantId && r.Name == "Draft");
            if (drafter == null)
            {
                drafter = _context.Roles.Add(new Role(_tenantId, "Draft", "Drafter") { IsStatic = true }).Entity;
                _context.SaveChanges();
            }

            // Grant all permissions to admin role
            GrantPermissions(adminRole);
            //Grant permissions to guideline admin role
            GrantPermissions(guidlineAdmin);
            //Grant permissions to drafter role
            GrantPermissions(drafter);

            // Admin user

            var adminUser = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == AbpUserBase.AdminUserName);
            if (adminUser == null)
            {
                adminUser = User.CreateTenantAdminUser(_tenantId, "admin@defaulttenant.com");
                adminUser.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(adminUser, "P@ssw0rd");
                adminUser.IsEmailConfirmed = true;
                adminUser.IsActive = true;

                _context.Users.Add(adminUser);
                _context.SaveChanges();

                // Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(_tenantId, adminUser.Id, adminRole.Id));
                _context.SaveChanges();
            }
        }

        private void GrantPermissions(Role role)
        {
            var grantedPermissions = new List<string>();
            var permissions = new List<Permission>();
            if (role.Name == StaticRoleNames.Tenants.Admin)
            {
                grantedPermissions = _context.Permissions.IgnoreQueryFilters()
                    .OfType<RolePermissionSetting>()
                    .Where(p => p.TenantId == _tenantId && p.RoleId == role.Id)
                    .Select(p => p.Name)
                    .ToList();
                permissions = PermissionFinder
                    .GetAllPermissions(new MyProjectAuthorizationProvider())
                    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant) &&
                        !grantedPermissions.Contains(p.Name))
                    .ToList();
            }

            if (role.Name.Equals("GLAdmin"))
            {
                grantedPermissions = _context.Permissions.IgnoreQueryFilters()
                    .OfType<RolePermissionSetting>()
                    .Where(p => p.TenantId == _tenantId && p.RoleId == role.Id)
                    .Select(p => p.Name)
                    .ToList();
                permissions = PermissionFinder
                    .GetAllPermissions(new MyProjectAuthorizationProvider())
                    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant) &&
                                !grantedPermissions.Contains(p.Name) && (p.Name.Equals(PermissionNames.Pages_About) || p.Name.Equals(PermissionNames.Pages_Users)))
                    .ToList();
            }


            if (role.Name.Equals("Draft"))
            {
                //    grantedPermissions = _context.Permissions.IgnoreQueryFilters()
                //        .OfType<RolePermissionSetting>()
                //        .Where(p => p.TenantId == _tenantId && p.RoleId == role.Id && p.Name.Equals(PermissionNames.Pages_About))
                //        .Select(p => p.Name)
                //        .ToList();
                //    permissions = PermissionFinder
                //        .GetAllPermissions(new MyProjectAuthorizationProvider())
                //        .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant) &&
                //                    grantedPermissions.Contains(p.Name) && (/* add permissions granted to Draft Role Here*/))
                //        .ToList();
            }

            if (permissions.Any())
            {
                _context.Permissions.AddRange(
                    permissions.Select(permission => new RolePermissionSetting
                    {
                        TenantId = _tenantId,
                        Name = permission.Name,
                        IsGranted = true,
                        RoleId = role.Id
                    })
                );
                _context.SaveChanges();
            }
        }
    }
}
