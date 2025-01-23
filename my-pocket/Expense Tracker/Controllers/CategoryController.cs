using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MY_POCKET.Models;

namespace MY_POCKET.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Category/Create
        public IActionResult CreateOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Category());
            else
                return View(_context.Categories.Find(id));
        }

        // POST: Category/CreateOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit([Bind("CategoryId,Title,Icon,Type")] Category category)
        {
            if (ModelState.IsValid)
            {
                // If the CategoryId is 0 ghansaybo  new category, 
                // bach manduroch manually set the CategoryId (auto-increment is handled by EF).
                if (category.CategoryId == 0)
                {
                    _context.Add(category);  // zid new category
                }
                else
                {
                    _context.Update(category);  // Update existing category
                }

                await _context.SaveChangesAsync();  // Save changes to the database
                return RedirectToAction(nameof(Index));  // sir  index page
            }

            return View(category);  // Return the same view if there are validation errors
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);  // 7yd the category from the context
            }

            await _context.SaveChangesAsync();  // Save changes to the database
            return RedirectToAction(nameof(Index));  // rja3 to the index page
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);  // Check if a category with the given ID exists
        }
    }
}
