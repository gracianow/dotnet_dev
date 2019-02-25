using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web.Configuration;
using WebAppAlunos.Models;

namespace WebAppAlunos.Utils
{
    public class Utilidades
    {
        private static ApplicationDbContext userContext = new ApplicationDbContext();
        private static DbDadosContext db = new DbDadosContext();

        private static void CheckRole(string roleName)
        {
            var roleName = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(userContext));

            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));

            }
        }

        public static void CheckSuperUser(string role)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(userContext));
            var email = WebConfigurationManager.AppSettings["AdminUser"];
            var password = WebConfigurationManager.AppSettings["AdminPassWord"];
            var userASP = userManager.FindByName(email);

            if (userASP == null)
            {
                CreateUserASP(email, role, password);
            }
        }

        private static void CreateUserASP(string email, string role, string password)
        {
            throw new NotImplementedException();
        }
    }
}