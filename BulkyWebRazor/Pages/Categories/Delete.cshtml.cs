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
                var Category =  _db.Categories.Find(id);

            }


        }
        public IActionResult OnDelete()
        {

            _db.Categories.Remove(Category);
            _db.SaveChanges();

            return RedirectToPage("Index");
        }
        


    }
}
