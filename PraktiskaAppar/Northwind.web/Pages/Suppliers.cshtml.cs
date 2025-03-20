using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Northwind.EntityModels;
using System.Security.Cryptography.X509Certificates; // för PageModel

namespace Northwind.web.Pages
{
    public class SuppliersModel : PageModel
    {
            private NorthwindDatabaseContext db;
        public SuppliersModel(NorthwindDatabaseContext db)
        {
            this.db = db;
        }
        public IEnumerable<Supplier>? Suppliers { get; set; }

        [BindProperty] // för att binda data från formuläret
        public Supplier? Supplier { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Northwind App- Suppliers";
            Suppliers = db.Suppliers.OrderBy(c => c.Country)
                .ThenBy(c => c.CompanyName);
        }

        public IActionResult OnPost()
        {
            if ((Supplier is not null) && ModelState.IsValid)
            {
                db.Suppliers.Add(Supplier);
                db.SaveChanges();
                return RedirectToPage("/suppliers");
            }
            else
            {
                return Page();// stanna kvar på sidan
            }
            
        }
    }   
}
