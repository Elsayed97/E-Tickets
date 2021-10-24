using E_Tickets.Data;
using E_Tickets.Data.Services;
using E_Tickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService service;

        public ProducersController(IProducersService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await service.GetAllAsync();
            return View(allProducers);
        }


        // Get: Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Producer producer)
        {
            if (ModelState.IsValid)
            {
                await service.CreateAsync(producer);
                return RedirectToAction("Index");
            }
            return View(producer);

        }


        // Get: Producers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producer = await service.GetByIdAsync(id);
            if (producer != null)
            {
                return View(producer);
            }
            return View("NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,ProfilePictureUrl,FullName,Bio")] Producer producer)
        {
            if (ModelState.IsValid)
            {
                await service.UpdateAsync(producer);
                return RedirectToAction("Index");
            }
            return View(producer);

        }

        // Get: Producers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await service.GetByIdAsync(id);
            if (producerDetails != null)
            {
                return View(producerDetails);
            }
            return View("NotFound");
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var producerDetails = await service.GetByIdAsync(Id);
            if (producerDetails != null)
            {
                await service.DeleteAsync(Id);
                return RedirectToAction("Index");
            }
            return View("NotFound");

        }




        // Get: Producers/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await service.GetByIdAsync(id);
            if (producerDetails != null)
            {
                return View(producerDetails);
            }
            return View("NotFound");
        }


    }
}
