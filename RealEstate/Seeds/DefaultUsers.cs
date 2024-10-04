using Bl;
using Microsoft.AspNetCore.Identity;
using RealEstate.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RealEstate.Seeds
{
    public static class DefaultUsers
    {



        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager)
        {
            var Admin = new ApplicationUser()
            {
                FirstName = "عادل",
                LastName = "العنزي",
                Email = "adel9809@hotmail.com",
                UserName = "adel9809@hotmail.com",
                EmailConfirmed = true,
            };
            var user = await userManager.FindByEmailAsync(Admin.Email);

            if (user == null)
            {
                await userManager.CreateAsync(Admin, "Opec1819@");
                await userManager.AddToRolesAsync(Admin, new List<string> {
                    Roles.Admin.ToString(),
                });
            }
        }



    }
}
