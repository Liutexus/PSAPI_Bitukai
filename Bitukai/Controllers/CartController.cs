using System.Linq;
using System.Threading.Tasks;
using Bitukai.Data;
using Bitukai.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bitukai.Migrations;
using Microsoft.AspNetCore.Identity;

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
        public async Task<IActionResult> AddToCart(Component newComponent)
        {


            if (CheckIfComponentExists(newComponent))
            {
                ViewData["ComponentExistsError"] = true; // Return a warning that component already exists
            }
            else
            {
                AddComponent(newComponent);
            }

            return View("ItemList");
        }

        // Function which checks whether the component exists inside user's cart.
        public bool CheckIfComponentExists(Component newComponent)
        {
            if (_context.ComponentCarts.Find(newComponent) == null) // Looks for existing component in the cart
                return false;
            return true;
        }
        // Function which adds a component inside user's cart.
        public void AddComponent(Component newComponent)
        {
            var userCart = _context.Carts.FirstOrDefault(); // This needs to get exact user's cart (no authentication atm)
            ComponentCart newCompCart = new ComponentCart(); // Creating new many-to-many intermediate entity

            // Assigning respective variables.
            newCompCart.CartId = userCart.Id;
            newCompCart.Cart = userCart;
            newCompCart.ComponentId = newComponent.Id;
            newCompCart.Component = newComponent;

            _context.ComponentCarts.Add(newCompCart); // Adding new entity to the database

            ViewData["ComponentAddSuccess"] = true; // Return a notification that component was added successfully
        }

        // Function which returns user's cart.
        public async Task<IActionResult> GetUserCart()
        {
            var userCart = _context.Carts.FirstOrDefault(); // This needs to get exact user's cart (no authentication atm)

            return View("ItemList", userCart);
        }

        // Edits a component inside user's cart.
        public async Task<IActionResult> EditCartComponent(Component oldComponent, Component newComponent)
        {
            var userCart = _context.Carts.FirstOrDefault(); // This needs to get exact user's cart

            ComponentCart oldCompCart = new ComponentCart(); // Creating many-to-many intermediate entity
            // Assigning respective variables.
            oldCompCart.CartId = userCart.Id;
            oldCompCart.Cart = userCart;
            oldCompCart.ComponentId = oldComponent.Id;
            oldCompCart.Component = oldComponent;

            userCart.ComponentCarts.Remove(oldCompCart); // Removing the entity

            if(newComponent != null) // Did the user specify other component?
            {
                ComponentCart newCompCart = new ComponentCart(); // Creating new many-to-many intermediate entity
                // Assigning respective variables.
                newCompCart.CartId = userCart.Id;
                newCompCart.Cart = userCart;
                newCompCart.ComponentId = newComponent.Id;
                newCompCart.Component = newComponent;

                userCart.ComponentCarts.Add(newCompCart); // Adding the new entity
            }

            return View("Index");
        }

        // Completely empty the user's cart
        public void PurgeUserCart()
        {
            var userCart = _context.Carts.FirstOrDefault(); // This needs to get exact user's cart
            userCart.ComponentCarts.Clear(); // Clearing all elements inside user's cart.
            ViewData["CartPurgeSuccess"] = true; // Return a success notification
        }


    }
}