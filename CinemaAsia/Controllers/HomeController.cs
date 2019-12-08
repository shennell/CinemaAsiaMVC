using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CinemaAsia.Models;
using CinemaAsia.Data;
using CinemaAsia.ViewModels;

namespace CinemaAsia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBrowseData browseData;

        public HomeController(ILogger<HomeController> logger, IBrowseData browseData)
        {
            _logger = logger;
            this.browseData = browseData;
        }

        public IActionResult Index()
        {
            var movies = browseData.GetLatestMovies();

            var homeViewModel = new homeViewModel()
            {
                Movies = movies.ToList()
            };

            return View(homeViewModel);
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
