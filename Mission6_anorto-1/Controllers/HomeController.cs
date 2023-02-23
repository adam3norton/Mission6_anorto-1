using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6_anorto_1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6_anorto_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext _movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext movies)
        {
            _logger = logger;
            _movieContext = movies;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(MovieRecord movie)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(movie);
                _movieContext.SaveChanges();
                return View("Confirmation", movie);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Collection()
        { 
            var movieCollection = _movieContext.Movies
                .Include(m => m.Category)
                .ToList();
            return View(movieCollection);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            var movie = _movieContext.Movies.Single(x => x.MovieId == movieid);
            return View("MovieForm", movie);
        }

        [HttpPost]
        public IActionResult Edit (MovieRecord mov)
        {
            _movieContext.Update(mov);
            _movieContext.SaveChanges();

            return RedirectToAction("Collection");
        }

        [HttpGet]
        public IActionResult Delete (int movieid)
        {
            var mov = _movieContext.Movies.Single(x => x.MovieId == movieid);
            return View(mov);
        }

        [HttpPost]
        public IActionResult Delete (MovieRecord mr)
        {
            _movieContext.Movies.Remove(mr);
            _movieContext.SaveChanges();

            return RedirectToAction("Collection");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
