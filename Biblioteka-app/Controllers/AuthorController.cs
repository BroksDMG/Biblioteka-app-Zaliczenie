using Biblioteka_app.Models;
using Biblioteka_app.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteka_app.Interfaces;
using System.Threading.Tasks;
using Biblioteka_app.Services;
using Microsoft.AspNetCore.Authorization;
using Biblioteka_app.Data.Static;

namespace Biblioteka_app.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class AuthorController : Controller
    {
        private readonly IAuthorsService _autorRepository;
        public AuthorController(IAuthorsService autorRepository)
        {
            _autorRepository = autorRepository;
        }
        // GET: Author
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var allAuthors = await _autorRepository.GetAllAsync();
            return View(allAuthors) ;
        }

        // GET: Author/Details/5
        [AllowAnonymous]
        public async Task<ActionResult> Details(int id)
        {
            return View(await _autorRepository.GetByIdAsync(id));
        }

        // GET: Author/Create
        public IActionResult Create()
        {
            return View(new AuthorModel());
        }

        // POST: Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorModel authorModel)
        {
           await _autorRepository.AddAsync(authorModel);
                return RedirectToAction(nameof(Index));
            
          
        }

        // GET: Author/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _autorRepository.GetByIdAsync(id));
        }

        // POST: Author/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AuthorModel authorModel)
        {
           await _autorRepository.UpdateAsync(id, authorModel);
                return RedirectToAction(nameof(Index));
           
        }

        // GET: Author/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _autorRepository.GetByIdAsync(id));
        }

        // POST: Author/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AuthorModel authorModel)
        {
            await _autorRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            
         
        }
     }
}
