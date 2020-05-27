using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Bitukai.Data;
using Bitukai.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bitukai.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void AddAsFavorite(int componentId)
        {
            UserFavoriteComponent userFavoriteComponent;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            var component = _context.Components.FirstOrDefault(c => c.Id == componentId);

            //User tempUser = new User(user);

            userFavoriteComponent = new UserFavoriteComponent {
                ComponentId = componentId,
                Component = component,
                UserId = userId,
                User = (User)user
            };
            //favoriteComponents.Add(component);

            Console.WriteLine(JsonConvert.SerializeObject(userFavoriteComponent));



        }





    }
}
