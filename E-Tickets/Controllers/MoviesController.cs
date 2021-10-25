using AutoMapper;
using E_Tickets.Data;
using E_Tickets.Data.Services;
using E_Tickets.Data.ViewModels;
using E_Tickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService service;
        private readonly IMapper mapper;

        public MoviesController(IMoviesService service,IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // Get: Movies
        public async Task<IActionResult> Index()
        {
            var allMovies = await service.GetAllAsync(m => m.Cinema);
            return View(allMovies);
        }

        // Get: Movies/Details/1

        public async Task<IActionResult> Details(int Id)
        {
            var movieDetails = await service.GetMovieByIdAsync(Id);
            return View(movieDetails);
        }

        //Get: Movies/Create

        public async Task<IActionResult> Create()
        {
            var dropDownValues = await service.GetMovieDropDownValues();
            ViewBag.Actors = new SelectList(dropDownValues.Actors,"Id","FullName");
            ViewBag.Cinemas = new SelectList(dropDownValues.Cinemas,"Id","Name");
            ViewBag.Producers = new SelectList(dropDownValues.Producers, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieVM movie)
        {
            if (ModelState.IsValid)
            {
                await service.AddNewMovieAsync(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // Get: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var dropDownValues = await service.GetMovieDropDownValues();
            ViewBag.Actors = new SelectList(dropDownValues.Actors, "Id", "FullName");
            ViewBag.Cinemas = new SelectList(dropDownValues.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(dropDownValues.Producers, "Id", "FullName");

            var movieDetails = await service.GetMovieByIdAsync(id);

            if(movieDetails != null)
            {
                var movieVM = mapper.Map<MovieVM>(movieDetails);
                return View(movieVM);
            }
            return View("NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MovieVM movie)
        {
            if (ModelState.IsValid)
            {
                await service.UpdateMovieAsync(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await service.GetAllAsync(m => m.Cinema);

            if (!String.IsNullOrEmpty(searchString))
            {
                var filteredMovies = allMovies.Where(m => m.Name.ToLower().Contains(searchString)
                                                    || m.Description.ToLower().Contains(searchString)).ToList();
                return View("Index", filteredMovies);
            }
            return View("Index",allMovies);
        }

    }
}
