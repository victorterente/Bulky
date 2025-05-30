﻿
using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAcess.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bulky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepository = db;
        }


        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepository.GetAll().ToList();
         
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
                _categoryRepository.Add(obj);
                _categoryRepository.Save();
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
            Category ?category = _categoryRepository.Get(u=>u.Id == id);
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
                _categoryRepository.Update(obj);
                _categoryRepository.Save();
               
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
            Category ?category = _categoryRepository.Get(u => u.Id == id);

            if(category == null)
            {
                return NotFound();
            }

            _categoryRepository.Remove(category);
            return View(category);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = _categoryRepository.Get(u => u.Id == id);
            if( category == null)
            {
                return NotFound();
            }

            _categoryRepository.Remove(category);
            _categoryRepository.Save();
            TempData["Success"] = category.Name + " category deleted successfully";
            return RedirectToAction("Index");
          
           


        }
        
       
    }
}
