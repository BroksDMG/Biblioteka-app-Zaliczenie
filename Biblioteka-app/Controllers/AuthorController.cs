using Biblioteka_app.Models;
using Biblioteka_app.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_app.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAutorRepository _autorRepository;
        public AuthorController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }
        // GET: Author
        public ActionResult Index()
        {
            return View(_autorRepository.GetAllActive) ;
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            return View(_autorRepository.Get(id));
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
            _autorRepository.Add(authorModel);
                return RedirectToAction(nameof(Index));
            
          
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_autorRepository.Get(id));
        }

        // POST: Author/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuthorModel authorModel)
        {
            _autorRepository.Update(id, authorModel);
                return RedirectToAction(nameof(Index));
           
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_autorRepository.Get(id));
        }

        // POST: Author/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AuthorModel authorModel)
        {
            _autorRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            
         
        }
     }
}
