﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Proiect.Models;

[assembly: OwinStartupAttribute(typeof(Proiect.Startup))]
namespace Proiect
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateAdminAndUserRoles();
        }
        private void CreateAdminAndUserRoles()
        {
            var ctx = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));

            // adaugam rolurile pe care le poate avea un utilizator
            // din cadrul aplicatiei
            if (!roleManager.RoleExists("Admin"))
            {
                // adaugam rolul de administrator
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                // se adauga utilizatorul administrator
                var user = new ApplicationUser();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";

                var adminCreated = userManager.Create(user, "Admin2020!");
                if (adminCreated.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("User"))
            {
                // adaugam rolul de administrator
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

                // se adauga utilizatorul administrator
                var user = new ApplicationUser();
                user.UserName = "user@user.com";
                user.Email = "user@user.com";

                var adminCreated = userManager.Create(user, "User2020!");
                if (adminCreated.Succeeded)
                {
                    userManager.AddToRole(user.Id, "User");
                }
            }
            // ATENTIE !!! Pentru proiecte, pentru a adauga un rol nou trebuie sa adaugati secventa:
            /*if (!roleManager.RoleExists("your_role_name"))
            {
            // adaugati rolul specific aplicatiei voastre
            var role = new IdentityRole();
            role.Name = "your_role_name";
            roleManager.Create(role);
            // se adauga utilizatorul
            var user = new ApplicationUser();
            user.UserName = "your_user_email";
            user.Email = "your_user_email";
            }*/
        }
    }
}
