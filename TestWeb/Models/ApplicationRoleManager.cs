using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace TestWeb.Models
{
    public class ApplicationRoleManager : RoleManager<ApplicationRol>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRol, string> roleStore)
        : base(roleStore) { }

        public static ApplicationRoleManager Create(
            IdentityFactoryOptions<ApplicationRoleManager> options,
            IOwinContext context)
        {
            var manager = new ApplicationRoleManager(
                new RoleStore<ApplicationRol>(context.Get<ApplicationDbContext>()));
            return manager;
        }
    }
}
