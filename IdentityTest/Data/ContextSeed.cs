using IdentityTest.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTest.Data
{
    public class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Models.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Models.Roles.User.ToString()));
        }

        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                FirstName = "Anna",
                LastName = "Lunder",
                City = new Cities { CityName = "Liverpool", Country = new Countries { CountryName = "England" } },
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "password");
                    await userManager.AddToRoleAsync(defaultUser, Models.Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Models.Roles.User.ToString());
                }

            }

            var userNoOne = new ApplicationUser
            {
                UserName = "Emma",
                Email = "emma@gmail.com",
                FirstName = "Emma",
                LastName = "Johansson",
                City = new Cities { CityName = "Gothenburg", Country = new Countries { CountryName = "Sweden" } },
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            }; if (userManager.Users.All(u => u.Id != userNoOne.Id))

            {
                var user = await userManager.FindByEmailAsync(userNoOne.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(userNoOne, "password");
                    await userManager.AddToRoleAsync(userNoOne, Models.Roles.User.ToString());
                }
            }

            var userNoTwo = new ApplicationUser
            {
                UserName = "Simon",
                Email = "simon@gmail.com",
                FirstName = "Simon",
                LastName = "Lunder",
                City = new Cities { CityName = "Oslo", Country = new Countries { CountryName = "Norway" } },
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            }; if (userManager.Users.All(u => u.Id != userNoTwo.Id))

            {
                var user = await userManager.FindByEmailAsync(userNoTwo.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(userNoTwo, "password");
                    await userManager.AddToRoleAsync(userNoTwo, Models.Roles.User.ToString());
                }

            }

            var userNoThree = new ApplicationUser
            {
                UserName = "Louise",
                Email = "louise@gmail.com",
                FirstName = "Louise",
                LastName = "Lunder",
                City = new Cities { CityName = "London", Country = new Countries { CountryName = "England" } },
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            }; if (userManager.Users.All(u => u.Id != userNoThree.Id))

            {
                var user = await userManager.FindByEmailAsync(userNoThree.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(userNoThree, "password");
                    await userManager.AddToRoleAsync(userNoThree, Models.Roles.User.ToString());
                }

            }
        }
    }
}