using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BulkyWebRazor.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly DbContextApplication _db;
        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(DbContextApplication db)
        {
              _db=db;
        }
        public IActionResult OnPost()
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["Success"] = (Category.Name + " Created Succesfully");
            return RedirectToPage("Index");
        }


    }
}
