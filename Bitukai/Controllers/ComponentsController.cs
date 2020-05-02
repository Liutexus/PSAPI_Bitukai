using System.Threading.Tasks;
using Bitukai.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bitukai.Controllers
{
    public class ComponentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComponentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetComponent(int id)
        {
            var component = await _context.Processors.FirstOrDefaultAsync(c => c.Id == id);
            return View(component);
        }
    }
}