using CinemaAsia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAsia.Data
{
    public interface IBrowseData
    {
        IEnumerable<Movie> GetLatestMovies();
        Movie GetMovieById(int movieId);

        IEnumerable<Movie> GetMoviesByCountry(Country country);

        IEnumerable<Movie> GetMoviesByGenre(Genre genre);
    }
}
