using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bitukai.Data;
using Bitukai.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Bitukai.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCart(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            //var cart = await _context.
            


            return View("ItemList", user);
        }

    }
}