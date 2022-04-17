﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace TestWeb.Models
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            return manager;
        }

        public async override Task<IdentityResult> AddToRoleAsync(string userId, string roleId)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.ApplicationUserRole.Add(new ApplicationUserRole
                    {
                        UserId = userId,
                        RoleId = roleId
                    });

                    ctx.SaveChanges();
                }

                return await Task.FromResult(IdentityResult.Success);
            }
            catch (Exception ex)
            {
                
                return await Task.FromResult(new IdentityResult(ex.Message));
            }
        }

        public async override Task<IdentityResult> AddToRolesAsync(string userId, params string[] roles)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    foreach (var roleId in roles)
                    {
                        ctx.ApplicationUserRole.Add(new ApplicationUserRole
                        {
                            UserId = userId,
                            RoleId = roleId
                        });
                    }

                    ctx.SaveChanges();
                }

                return await Task.FromResult(IdentityResult.Success);
            }
            catch (Exception ex)
            {
                
                return await Task.FromResult(new IdentityResult(ex.Message));
            }
        }

        public async new Task<IEnumerable<ApplicationRol>> GetRolesAsync(string userId)
        {
            IEnumerable<ApplicationRol> result = new List<ApplicationRol>();

            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var roles = ctx.ApplicationUserRole.Where(x => x.UserId == userId).Select(x => x.RoleId).ToList();
                    result = ctx.ApplicationRoles.Where(x => roles.Contains(x.Id)).OrderBy(x => x.Name).ToList();
                }
            }
            catch (Exception ex)
            {
                
            }

            return await Task.FromResult(result);
        }

        public async override Task<bool> IsInRoleAsync(string userId, string roleId)
        {
            var result = false;

            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    result = ctx.ApplicationUserRole.Any(x => x.UserId == userId && x.RoleId == roleId);
                }
            }
            catch (Exception ex)
            {
                
            }

            return await Task.FromResult(result);
        }

        public async override Task<IdentityResult> RemoveFromRoleAsync(string userId, string roleId)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var roles = ctx.ApplicationUserRole.Where(x => x.RoleId == roleId && x.UserId == userId).ToList();
                    ctx.Entry(roles).State = EntityState.Deleted;

                    ctx.SaveChanges();
                }

                return await Task.FromResult(IdentityResult.Success);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new IdentityResult(ex.Message));
            }
        }

        public async override Task<IdentityResult> RemoveFromRolesAsync(string userId, params string[] roles)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var rolesPerUser = ctx.ApplicationUserRole.Where(x => roles.Contains(x.RoleId) && x.UserId == userId).ToList();
                    ctx.Entry(rolesPerUser).State = EntityState.Deleted;

                    ctx.SaveChanges();
                }

                return await Task.FromResult(IdentityResult.Success);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new IdentityResult(ex.Message));
            }
        }
    }
}