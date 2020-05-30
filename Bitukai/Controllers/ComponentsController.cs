using Bitukai.Data;
using Bitukai.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bitukai.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Bitukai.Controllers
{
    public class ComponentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ComponentsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
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

            ViewData["FavExistsError"] = TempData["FavExistsError"];
            ViewData["FavAdded"] = TempData["FavAdded"];

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
            var comparisonComponents = await _context.Processors.Where(p => p.Id != id).ToListAsync();
            ViewBag.ComparisonComponents = new SelectList(comparisonComponents, "Id", "Name");
            TempData["OriginalComponentId"] = component.Id;
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

        [HttpPost]
        public async Task<IActionResult> GetOtherComponent()
        {
            var originalComponentId = (int)TempData["OriginalComponentId"];
            var comparisonComponentId = int.Parse(Request.Form["ComparisonComponents"]);

            var componentsToCompare = new List<Processor>
            {
                await _context.Processors.FirstAsync(p => p.Id == originalComponentId),
                await _context.Processors.FirstAsync(p => p.Id == comparisonComponentId)
            };

            return View("CompareComponents", componentsToCompare);
        }

        public async Task<IActionResult> AddAsFavorite(int componentId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                var favoriteExists = await _context.UserFavoriteComponents
                    .AnyAsync(f => f.UserId == user.Id && f.ComponentId == componentId);

                if (favoriteExists)
                {
                    TempData["FavExistsError"] = true;
                    TempData["FavAdded"] = null;
                }
                else
                {
                    await _context.UserFavoriteComponents.AddAsync(new UserFavoriteComponent
                        {ComponentId = componentId, UserId = user.Id});
                    await _context.SaveChangesAsync();
                    TempData["FavExistsError"] = null;
                    TempData["FavAdded"] = true;
                }
                return RedirectToAction("GetComponent", new { id = componentId });
            }

            return Unauthorized();
        }
    }
}