using Bitukai.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
                Tdp = 3.4,
                Price = 50.23M
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
                    Tdp = 3.4,
                    Price = 123.23M
                }
            };
            builder.Entity<Processor>().HasData(processors);
        }

        public static void SeedUsers(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
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

            if (!dbContext.Carts.Any())
            {
                var user = userManager.Users.First(u => u.Email == "employee@email.com");
                dbContext.Carts.Add(new Cart
                {
                    TotalPrice = 0.0f,
                    UserId = user.Id
                });
                dbContext.SaveChanges();
                user.CartId = dbContext.Carts.First().Id;
                userManager.UpdateAsync(user).Wait();
            }

            if (!dbContext.Comments.Any())
            {
                var user = userManager.Users.First(u => u.Email == "employee@email.com");
                dbContext.Comments.AddRange(new List<Comment>
                {
                    new Comment
                    {
                        ComponentId = 2, CreatedAt = new DateTime(2020, 5, 25),
                        Description = "Some informative description for demo.", UserId = user.Id
                    },
                    new Comment
                    {
                        ComponentId = 2, CreatedAt = new DateTime(2020, 5, 26),
                        Description = "Another informative description for demo.", UserId = user.Id
                    },
                    new Comment
                    {
                        ComponentId = 2, CreatedAt = new DateTime(2020, 5, 27),
                        Description = "Last informative description for demo.", UserId = user.Id
                    }
                });
                dbContext.SaveChanges();
            }
        }
    }
}
