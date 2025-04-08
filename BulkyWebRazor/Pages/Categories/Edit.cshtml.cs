using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly DbContextApplication _db;

        public Category? Category { get; set; }
        public EditModel(DbContextApplication db)
        {
            _db = db;
        }


        public void OnGet(int id)
        {
            var Category = _db.Categories.Find(id);
        }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

                _db.Categories.Update(Category);  
                _db.SaveChanges();

            }else
            {

                return BadRequest();
            }
            


            return RedirectToPage("Index");
        }
    }
}
