using Biblioteka_app.Interfaces;
using Biblioteka_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteka_app.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Biblioteka_app.Data.Static;

namespace Biblioteka_app.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        // GET: BookController
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var allMovies = await _bookRepository.GetAllActive(); 
            return View(allMovies);
        }

        // GET: BookController/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            return View(_bookRepository.Get(id));
        }

        // GET: BookController/Create
        
        public ActionResult Create()
        {
            return View(new BookModel());
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookModel bookModel)
        {
                 _bookRepository.Add(bookModel);
                return RedirectToAction(nameof(Index));
            
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_bookRepository.Get(id));
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookModel bookModel)
        {
                 _bookRepository.Update(id, bookModel);
                 return RedirectToAction(nameof(Index));
            
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_bookRepository.Get(id));
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BookModel bookModel)
        {
                 _bookRepository.Delete(id);
                return RedirectToAction(nameof(Index));
           
        }
    }
}
