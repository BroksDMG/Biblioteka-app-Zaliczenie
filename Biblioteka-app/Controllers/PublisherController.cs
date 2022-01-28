using Biblioteka_app.Data.Static;
using Biblioteka_app.Interfaces;
using Biblioteka_app.Models;
using Biblioteka_app.Repositories;
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
    public class PublisherController : Controller

    {

        private readonly IPublishersService _PublisherRepository;
        public PublisherController(IPublishersService publisherRepository)
        {
            _PublisherRepository = publisherRepository;
        }
        // GET: PublisherController
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allPublishers = await _PublisherRepository.GetAllAsync();
            return View(allPublishers);
        }

        // GET: PublisherController/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            
            return View(await _PublisherRepository.GetByIdAsync(id));
        }

        // GET: PublisherController/Create
        public IActionResult Create()
        {
            return View(new PublisherModel());
        }

        // POST: PublisherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PublisherModel publisherModel)
        {
            await _PublisherRepository.AddAsync(publisherModel);
                return RedirectToAction(nameof(Index));
         
        }

        // GET: PublisherController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _PublisherRepository.GetByIdAsync(id));
        }

        // POST: PublisherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Edit(int id, PublisherModel publisherModel)
        {
                await _PublisherRepository.UpdateAsync(id,publisherModel);
                return RedirectToAction(nameof(Index));
           
        }

        // GET: PublisherController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _PublisherRepository.GetByIdAsync(id));
        }

        // POST: PublisherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, PublisherModel publisherModel)
        {
             await _PublisherRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
           
        }
    }
}
