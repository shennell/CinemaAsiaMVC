using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAsia.Models;

namespace CinemaAsia.Data
{
    public class BrowseData : IBrowseData
    {
        private readonly ApplicationDbContext applicationDbContext;

        public BrowseData(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Movie> GetLatestMovies()
        {
            return applicationDbContext.Movies.Take(12);
        }

        public Movie GetMovieById(int movieId)
        {
            return applicationDbContext.Movies.FirstOrDefault(m => m.Id == movieId);
        }

        public IEnumerable<Movie> GetMoviesByCountry(Country country)
        {
            return applicationDbContext.Movies.Where(m => m.Country == country);
        }

        public IEnumerable<Movie> GetMoviesByGenre(Genre genre)
        {
            return applicationDbContext.Movies.Where(m => m.Genre == genre);
        }
    }
}
