 using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AplicationDBcontext _dbcontext;
        public CategoryController(AplicationDBcontext db)
        {
            _dbcontext = db;
        }


        public IActionResult Index()
        {
            List<Category> objCategoryList = _dbcontext.Categories.ToList();
         
            return View(objCategoryList);
        }

        public IActionResult Create() { 
            Category category = new Category();
            var Name = category.Name;
            int DisplayOrder = category.DisplayOrder; 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot  exactly match the Name");
            }

            if (ModelState.IsValid)
            {
                _dbcontext.Categories.Add(obj);
                _dbcontext.SaveChanges();
                TempData["Success"] = obj.Name + " category created successfully";

                return RedirectToAction("Index");
            }

            return View();
            
            
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category ?category = _dbcontext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();

            }
         
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Categories.Update(obj);
                _dbcontext.SaveChanges();
               
                TempData["Success"] = obj.Name + " category Updated successfully";

                return RedirectToAction("Index");
            }

            return View();


        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category ?category = _dbcontext.Categories.Find(id);

            if(category == null)
            {
                return NotFound();
            }

            _dbcontext.Categories.Remove(category);
            return View(category);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = _dbcontext.Categories.Find(id);
            if( category == null)
            {
                return NotFound();
            }
          
            _dbcontext.Categories.Remove(category);
            _dbcontext.SaveChanges();
            TempData["Success"] = category.Name + " category deleted successfully";
            return RedirectToAction("Index");
          
           


        }
        
       
    }
}
