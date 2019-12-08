using CinemaAsia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAsia.Data
{
    public interface IWatchlistData
    {
        List<Watchlist> GetUserWatchlist(string userId);
        Watchlist GetWatchlist(int Id);
        void AddMovieToWatchlist(Watchlist watchlist);
        void DeleteMovieFromWatchlist(Watchlist watchlist);
        Watchlist GetWatchlistByMovie(int movieId, string UserId);
    }
}
