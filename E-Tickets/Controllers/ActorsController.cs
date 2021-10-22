using E_Tickets.Data;
using E_Tickets.Data.Services;
using E_Tickets.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService service;
        

        public ActorsController(IActorsService service)
        {
            this.service = service;
            
        }

        // Get: Actors
        public async Task<IActionResult> Index()
        {
            var allActors = await service.GetAllAsync();
            return View(allActors);
        }

        // Get: Actors/Create
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")]Actor actor)
        {
            if (ModelState.IsValid)
            {
                await service.CreateAsync(actor);
                return RedirectToAction("Index");
            }
            return View(actor);
            
        }


        // Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actor = await service.GetByIdAsync(id);
            if(actor != null)
            {
                return View(actor);
            }
            return View("NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id,[Bind("Id,ProfilePictureUrl,FullName,Bio")]Actor actor)
        {
            if (ModelState.IsValid)
            {
                await service.UpdateAsync(Id , actor);
                return RedirectToAction("Index");
            }
            return View(actor);

        }

        // Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await service.GetByIdAsync(id);
            if (actorDetails != null)
            {
                return View(actorDetails);
            }
            return View("NotFound");
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var actorDetails = await service.GetByIdAsync(Id);
            if(actorDetails != null)
            {
                await service.DeleteAsync(Id);
                return RedirectToAction("Index");
            }
            return View("NotFound");

        }




        // Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await service.GetByIdAsync(id);
            if(actorDetails != null)
            {
                return View(actorDetails);
            }
            return View("NotFound");
        }
    }
}
