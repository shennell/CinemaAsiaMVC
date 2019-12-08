using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAsia.Data;
using CinemaAsia.Models;
using Microsoft.AspNetCore.Mvc;
using CinemaAsia.ViewModels;

namespace CinemaAsia.Controllers
{
    public class BrowseController : Controller
    {
        private readonly IBrowseData browseData;

        public BrowseController(IBrowseData browseData)
        {
            this.browseData = browseData;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("Browse/Country/{selection}")]
        public IActionResult Country(Country selection)
        {
            var movies = browseData.GetMoviesByCountry(selection);
            var title = selection == Models.Country.HK ? "Hong Kong" : selection.ToString();

            var countryViewModel = new countryViewModel()
            {
                Title = title,
                Movies = movies.ToList()
            };

            return View(countryViewModel);
        }

        [Route("Browse/Genre/{selection}")]
        public IActionResult Genre(Genre selection)
        {
            var movies = browseData.GetMoviesByGenre(selection);
            var title = selection.ToString();

            var genreViewModel = new genreViewModel()
            {
                Title = title,
                Movies = movies.ToList()
            };

            return View(genreViewModel);
        }

        public IActionResult Movie(int Id)
        {
            var movie = browseData.GetMovieById(Id);

            return View(movie);
        }
    }
}