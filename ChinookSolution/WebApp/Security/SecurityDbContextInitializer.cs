using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region Additional Namespaces
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
using System.Data.Entity;
using WebApp.Models;
using ChinookSystem.BLL;
#endregion

namespace WebApp.Security
{
    public class SecurityDbContextInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            #region Seed the roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var startupRoles = ConfigurationManager.AppSettings["startupRoles"].Split(';');
            foreach (var role in startupRoles)
                roleManager.Create(new IdentityRole { Name = role });

            //take roles from your Db such as position field from the employee table.
            //  or off some other record. 
            //We have a title column on the employees table which hold the roles
            EmployeeController sysmgr = new EmployeeController();
            List<string> employeeroles = sysmgr.Employees_GetTitles();
            foreach (var role in employeeroles)
                roleManager.Create(new IdentityRole { Name = role });
            #endregion

            #region Seed the users
           
            //hard coding a new user example
            string userPassword = ConfigurationManager.AppSettings["newUserPassword"];
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var result = userManager.Create(new ApplicationUser
            {
                UserName = "HansenB",
                Email = "hansenB@hotmail.somewhere.ca",
                CustomerId = 4
            }, userPassword);
            if (result.Succeeded)
                userManager.AddToRole(userManager.FindByName("HansenB").Id, "Customers");

            string customerUser = ConfigurationManager.AppSettings["customerUserName"];
            string customerRole = ConfigurationManager.AppSettings["customerRole"];
            string customerEmail = ConfigurationManager.AppSettings["customerEmail"];
            string customerPassword = ConfigurationManager.AppSettings["customerPassword"];
          
            result = userManager.Create(new ApplicationUser
            {
                UserName = customerUser,
                Email = customerEmail,
                CustomerId = 4
            }, customerPassword);
            if (result.Succeeded)
                userManager.AddToRole(userManager.FindByName(customerUser).Id, customerRole);

            //seeding employees from the employee table
            //TODO List:
            // Retreive a List<Employee> from the database
            //foreach employee
            // UserName such as LastName and FirstInitial possibly add a number
            // Email of employee or null or add @Chinook.somewhere.ca to UserName
            // Employee id is the pKey of the employee record
            //use the appSetting newUserPassword for the password
            // Succeeded, role can come from the Employee record

            #endregion

            // ... etc. ...

            base.Seed(context);
        }
    }
}