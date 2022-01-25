using Biblioteka_app.Interfaces;
using Biblioteka_app.Models;
using Biblioteka_app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_app.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoiresService _CategoryRepository;
        public CategoryController(ICategoiresService categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }
        // GET: CategoryController
        public async Task<ActionResult> Index()

        {
            var allCategory =await _CategoryRepository.GetAllAsync();
            return View(allCategory);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View(new CategoryModel());
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryModel categoryModel)
        {
               _CategoryRepository.AddAsync(categoryModel);
                return RedirectToAction(nameof(Index));
            
            
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_CategoryRepository.GetByIdAsync(id));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryModel categoryModel)
        {
              _CategoryRepository.UpdateAsync(id,categoryModel);
                return RedirectToAction(nameof(Index));
            
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_CategoryRepository.GetByIdAsync(id));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CategoryModel categoryModel)
        {
                _CategoryRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
           
        }
    }
}
