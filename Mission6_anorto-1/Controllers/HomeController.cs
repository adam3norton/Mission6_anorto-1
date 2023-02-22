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
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(MovieRecord movie)
        {
            _movieContext.Add(movie);
            _movieContext.SaveChanges();
            return View("Confirmation", movie);
        }

        [HttpGet]
        public IActionResult Collection()
        { 
            var movieCollection = _movieContext.Movies
                .Include(m => m.Category)
                .ToList();
            return View(movieCollection);
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
