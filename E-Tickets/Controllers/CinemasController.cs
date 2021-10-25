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
    public class CinemasController : Controller
    {
        private readonly ICinemasService service;

        public CinemasController(ICinemasService service)
        {
            this.service = service;
        }
        // Get: Cinemas
        public async Task<IActionResult> Index()
        {
            var allCinemas = await service.GetAllAsync();
            return View(allCinemas);
        }

        // Get: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                await service.CreateAsync(cinema);
                return RedirectToAction("Index");
            }
            return View(cinema);

        }


        // Get: Cinemas/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await service.GetByIdAsync(id);
            if (cinema != null)
            {
                return View(cinema);
            }
            return View("NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                await service.UpdateAsync(cinema);
                return RedirectToAction("Index");
            }
            return View(cinema);

        }

        // Get: Cinemas/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await service.GetByIdAsync(id);
            if (cinemaDetails != null)
            {
                return View(cinemaDetails);
            }
            return View("NotFound");
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var actorDetails = await service.GetByIdAsync(Id);
            if (actorDetails != null)
            {
                await service.DeleteAsync(Id);
                return RedirectToAction("Index");
            }
            return View("NotFound");

        }




        // Get: Cinemas/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await service.GetByIdAsync(id);
            if (cinemaDetails != null)
            {
                return View(cinemaDetails);
            }
            return View("NotFound");
        }
    }
}
