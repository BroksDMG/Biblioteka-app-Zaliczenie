using Biblioteka_app.Interfaces;
using Biblioteka_app.Models;
using Biblioteka_app.Repositories;
using Biblioteka_app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_app.Controllers
{
    public class PublisherController : Controller

    {

        private readonly IPublishersService _PublisherRepository;
        public PublisherController(IPublishersService publisherRepository)
        {
            _PublisherRepository = publisherRepository;
        }
        // GET: PublisherController
        public async Task<ActionResult> Index()
        {
            var allPublishers = await _PublisherRepository.GetAllAsync();
            return View(allPublishers);
        }

        // GET: PublisherController/Details/5
        public ActionResult Details(int id)
        {
            
            return View(_PublisherRepository.GetByIdAsync(id));
        }

        // GET: PublisherController/Create
        public ActionResult Create()
        {
            return View(new PublisherModel());
        }

        // POST: PublisherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PublisherModel publisherModel)
        {
            _PublisherRepository.AddAsync(publisherModel);
                return RedirectToAction(nameof(Index));
         
        }

        // GET: PublisherController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_PublisherRepository.GetByIdAsync(id));
        }

        // POST: PublisherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PublisherModel publisherModel)
        {
                _PublisherRepository.UpdateAsync(id,publisherModel);
                return RedirectToAction(nameof(Index));
           
        }

        // GET: PublisherController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_PublisherRepository.GetByIdAsync(id));
        }

        // POST: PublisherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PublisherModel publisherModel)
        {
             _PublisherRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
           
        }
    }
}
