using Bitukai.Data;
using Bitukai.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            ViewData["ComponentExistsError"] = TempData["ComponentExistsError"];
            ViewData["ComponentAdded"] = TempData["ComponentAdded"];

            if (component.AlternativeIds == string.Empty)
            {
                ViewData["EmptyListError"] = true;
            }
            else
            {
                component.Alternatives = await GetAlternatives(component);
                component.Comments = await GetCommentsWithAuthors(component);

                if (!component.Comments.Any())
                {
                    ViewData["EmptyCommentsError"] = true;
                }
            }

            return View("ComponentDetails", component);
        }

        private async Task<IEnumerable<Component>> GetAlternatives(Component component)
        {
            var alternativeIds = component.AlternativeIds.Split(';');
            var alternatives = new List<Processor>();
            foreach (var alternativeId in alternativeIds)
            {
                var alternative = await _context.Processors.FirstOrDefaultAsync(c => c.Id == int.Parse(alternativeId));
                alternatives.Add(alternative);
            }

            return alternatives;
        }
        private async Task<ICollection<Comment>> GetCommentsWithAuthors(Component component)
        {
            var commentsWithAuthors = await _context.Comments.Include(c => c.User).Where(c => c.ComponentId == component.Id).ToListAsync();

            return commentsWithAuthors;
        }

        public async Task<IActionResult> GetComponents(int categoryId)
        {
            var components = await _context.Components.Where(c => c.CategoryId == categoryId).ToListAsync();

            return View("ComponentList", components);
        }
    }
}