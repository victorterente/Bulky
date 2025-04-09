using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BulkyWebRazor.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        public readonly DbContextApplication _db;

        public Category? Category { get; set; }

        public DeleteModel(DbContextApplication db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            if(id != 0 && id != null)
            {
              Category =  _db.Categories.Find(id);

            }


        }
        public IActionResult OnPost()
        {
            Category obj = _db.Categories.Find(Category.Id);
            if(obj == null)
            {
                return NotFound();  

            }

            _db.Categories.Remove(obj);
            _db.SaveChanges();

            return RedirectToPage("Index");
        }
        


    }
}
