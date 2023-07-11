using CitasSalonApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(CitasSalonApp.Startup))]
namespace CitasSalonApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoleAndUser();
        }

        private void CreateRoleAndUser()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var rolManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!rolManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                rolManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "jeff@gmail.com";
                user.Email = "jeff@gmail.com";
                string PDW = "123456";

                var chkUser = userManager.Create(user, PDW);
                if (chkUser.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}
