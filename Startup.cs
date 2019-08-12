using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using RoleProject.Models;

[assembly: OwinStartupAttribute(typeof(RoleProject.Startup))]
namespace RoleProject
{
    public partial class Startup
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        public void createRole()
        {
            var rolemanger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            IdentityRole role;
            if (!rolemanger.RoleExists("Agince")) {
                role = new IdentityRole();
                role.Name = "Agince";
                rolemanger.Create(role);
            }

        }
    }
}
