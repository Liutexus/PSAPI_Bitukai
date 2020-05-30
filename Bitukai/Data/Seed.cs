using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bitukai.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bitukai.Data
{
    public static class Seed
    {
        public static void SeedData(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Processors"
            });

            var processor = new Processor
            {

                Id = 1,
                Manufacturer = "Intel",
                Name = "Core i5-2134",
                AlternativeIds = string.Empty,
                CategoryId = 1,
                CoreClockGhz = 2.3f,
                IntegratedGpu = "Gpu",
                CoreCount = 4,
                Socket = "AM4",
                Tdp = 3.4
            };
            var processors = new List<Processor>()
            {
                processor,
                new Processor
                {

                    Id = 2,
                    Manufacturer = "AMD",
                    Name = "Ryzen 7 3700",
                    AlternativeIds = "1",
                    CategoryId = 1,
                    CoreClockGhz = 3.7f,
                    IntegratedGpu = "Gpu",
                    CoreCount = 8,
                    Socket = "AM4",
                    Tdp = 3.4
                }
            };
            builder.Entity<Processor>().HasData(processors);
        }

        public static void SeedUsers(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Customer").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Customer"
                };
                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Employee"
                };
                roleManager.CreateAsync(role).Wait();
            }

            if (userManager.GetUsersInRoleAsync("Employee").Result.Count <= 0)
            {
                var user = new User
                {
                    UserName = "employee@email.com",
                    Email = "employee@email.com",
                    EmailConfirmed = true
                };
                var result = userManager.CreateAsync(user, "Employee1!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Employee").Wait();
                }
            }
        }
    }
}
