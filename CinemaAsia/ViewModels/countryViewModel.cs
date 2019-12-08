using CinemaAsia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAsia.ViewModels
{
    public class countryViewModel
    {
        public string Title { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
