using Microsoft.AspNetCore.Mvc;
using Northwind.EntityModels;
using Northwind.Mvc.Data;

namespace Northwind.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly NorthwindDatabaseContext _db;

        public CategoryController(NorthwindDatabaseContext db)
        {
            _db = db;
        }
        [Route("category/{id}")]
        public IActionResult CategoryDetails(int id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
    }
}

