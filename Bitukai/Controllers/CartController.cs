using Bitukai.Data;
using Bitukai.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bitukai.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public CartController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);

            return View("Index", user);
        }

        // Function which adds a components to user's cart.
        public async Task<IActionResult> AddToCart(int componentId)
        {
            var user = await GetCurrentUser();
            var cart = await _context.Carts.FirstAsync(c => c.UserId == user.Id);

            if (CheckIfComponentExists(componentId, cart))
            {
                TempData["ComponentExistsError"] = true;
                TempData["ComponentAdded"] = null;
            }
            else
            {
                await _context.ComponentCarts.AddAsync(new ComponentCart
                {
                    CartId = cart.Id,
                    ComponentId = componentId
                });
                await _context.SaveChangesAsync();
                TempData["ComponentExistsError"] = null;
                TempData["ComponentAdded"] = true;
            }

            return RedirectToAction("GetComponent", "Components", new {id = componentId});
        }

        private async Task<User> GetCurrentUser()
        {
            if (User is null)
            {
                throw new UnauthorizedAccessException("You must be logged in.");
            }

            return await _userManager.FindByEmailAsync(User.Identity.Name);
        }

        // Function which checks whether the component exists inside user's cart.
        private bool CheckIfComponentExists(int componentId, Cart userCart)
        {
            if (_context.ComponentCarts.Any(cc => cc.CartId == userCart.Id && cc.ComponentId == componentId))
            {
                return true;
            }

            return false;
        }

        // Function which returns user's cart.
        public IActionResult GetUserCart()
        {
            var userCart = _context.Carts.FirstOrDefault(); // This needs to get exact user's cart (no authentication atm)

            return View("ItemList", userCart);
        }
    }
}