using Bitukai.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bitukai.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetCategories()
        {
            var categories =  await _context.Categories.ToListAsync();

            return View("CategoryList", categories);
        }
    }
}
