using CinemaAsia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAsia.Data
{
    public class WatchlistData : IWatchlistData
    {
        private readonly ApplicationDbContext applicationDbContext;

        public WatchlistData(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public void AddMovieToWatchlist(Watchlist watchlist)
        {
            applicationDbContext.Watchlists.Add(watchlist);
            applicationDbContext.SaveChanges();
        }

        public void DeleteMovieFromWatchlist(Watchlist watchlist)
        {
            applicationDbContext.Watchlists.Remove(watchlist);
            applicationDbContext.SaveChanges();
        }

        public List<Watchlist> GetUserWatchlist(string userId)
        {
            return applicationDbContext.Watchlists
                .Include(w => w.Movie)
                .Where(w => w.UserId.Equals(userId))
                .ToList();
        }

        public Watchlist GetWatchlist(int Id)
        {
            return applicationDbContext.Watchlists.FirstOrDefault(w=>w.Id==Id);
        }

        public Watchlist GetWatchlistByMovie(int movieId, string userId)
        {
            return applicationDbContext.Watchlists.FirstOrDefault(w=>w.MovieId==movieId && w.UserId == userId);
        }
    }
}
