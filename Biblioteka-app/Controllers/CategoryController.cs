using Biblioteka_app.Data.Static;
using Biblioteka_app.Interfaces;
using Biblioteka_app.Models;
using Biblioteka_app.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_app.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CategoryController : Controller
    {
        private readonly ICategoiresService _CategoryRepository;
        public CategoryController(ICategoiresService categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }
        // GET: CategoryController
        [AllowAnonymous]
        public async Task<IActionResult> Index()

        {
            var allCategory =await _CategoryRepository.GetAllAsync();
            return View(allCategory);
        }

        // GET: CategoryController/Create
        public IActionResult Create()
        {
            return View(new CategoryModel());
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryModel categoryModel)
        {
               await _CategoryRepository.AddAsync(categoryModel);
                return RedirectToAction(nameof(Index));
            
            
        }

        // GET: CategoryController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _CategoryRepository.GetByIdAsync(id));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryModel categoryModel)
        {
             await _CategoryRepository.UpdateAsync(id,categoryModel);
                return RedirectToAction(nameof(Index));
            
        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _CategoryRepository.GetByIdAsync(id));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, CategoryModel categoryModel)
        {
               await _CategoryRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
           
        }
    }
}
