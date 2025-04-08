using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly DbContextApplication _db;

        public List<Category> CategoryList { get; set; }
        public IndexModel( DbContextApplication db)
        {
            _db= db ;
        }
        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();


        }
    }
}
