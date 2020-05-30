using System;
using System.Collections.Generic;
using System.Linq;
using Bitukai.Data;
using Bitukai.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Diagnostics;
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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCategories()
        {
            var category =  _context.Categories.ToList();

            return View("~/Views/Home/Index.cshtml", category);
        }
        
        public IActionResult openComponentList(string category)
        {
            var categories = _context.Components.Where(b => b.Category.Name == category).ToList();

            if (categories.Count == 0)
            {
                ViewBag.message = "There is no components under this category";
            }

            return View("ComponentList", categories);
        }
        
        
    }
}
