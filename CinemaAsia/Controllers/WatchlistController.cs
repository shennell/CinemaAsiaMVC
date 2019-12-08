using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAsia.Data;
using CinemaAsia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAsia.Controllers
{
    [Authorize]
    public class WatchlistController : Controller
    {
        private readonly IWatchlistData watchlistData;
        private readonly UserManager<ApplicationUser> userManager;

        public WatchlistController(IWatchlistData watchlistData, UserManager<ApplicationUser> userManager)
        {
            this.watchlistData = watchlistData;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = userManager.GetUserId(HttpContext.User);
            var watchlists = watchlistData.GetUserWatchlist(userId);
            return View(watchlists);
        }

        public IActionResult Add(int movieId)
        {
            var userId = userManager.GetUserId(HttpContext.User);
            var existingMovie = watchlistData.GetWatchlistByMovie(movieId, userId);

            if(existingMovie == null)
            {
                
                var watchlist = new Watchlist
                {
                    MovieId = movieId,
                    UserId = userId
                };

                watchlistData.AddMovieToWatchlist(watchlist);

                TempData["ResultMessage"] = "The movie has been added to your watchlist.";
                TempData["AlertClass"] = "alert alert-success";
            }
            else
            {
                TempData["ResultMessage"] = "This movie already exists in your watchlist.";
                TempData["AlertClass"] = "alert alert-danger";
            }


            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int Id)
        {
            var watchlist = watchlistData.GetWatchlist(Id);

            watchlistData.DeleteMovieFromWatchlist(watchlist);

            TempData["ResultMessage"] = "The movie has been removed from your watchlist.";
            TempData["AlertClass"] = "alert alert-success";
            return RedirectToAction(nameof(Index));
        }
    }
}