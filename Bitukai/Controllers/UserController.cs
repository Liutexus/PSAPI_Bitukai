using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Bitukai.Data;
using Bitukai.Migrations;
using Bitukai.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bitukai.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task AddAsFavorite(int componentId)
        {
            UserFavoriteComponent userFavoriteComponent;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var user = await _userManager.FindByIdAsync(userId);

            var component = _context.Components.FirstOrDefault(c => c.Id == componentId);

            //User tempUser = new User(user);

            userFavoriteComponent = new UserFavoriteComponent {
                ComponentId = componentId,
                Component = component,
                UserId = userId,
                User = (User)user
            };
            //favoriteComponents.Add(component);
        }
    }
}
