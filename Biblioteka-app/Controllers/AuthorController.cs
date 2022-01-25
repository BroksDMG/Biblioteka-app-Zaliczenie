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

namespace Biblioteka_app.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorsService _autorRepository;
        public AuthorController(IAuthorsService autorRepository)
        {
            _autorRepository = autorRepository;
        }
        // GET: Author
        public async Task<ActionResult> Index()
        {
            var allAuthors = await _autorRepository.GetAllAsync();
            return View(allAuthors) ;
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            return View(_autorRepository.GetByIdAsync(id));
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View(new AuthorModel());
        }

        // POST: Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorModel authorModel)
        {
            _autorRepository.AddAsync(authorModel);
                return RedirectToAction(nameof(Index));
            
          
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_autorRepository.GetByIdAsync(id));
        }

        // POST: Author/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuthorModel authorModel)
        {
            _autorRepository.UpdateAsync(id, authorModel);
                return RedirectToAction(nameof(Index));
           
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_autorRepository.GetByIdAsync(id));
        }

        // POST: Author/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AuthorModel authorModel)
        {
            _autorRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            
         
        }
     }
}
