using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAsia.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Year")]
        public int YearOfRelease { get; set; }
        [Required]
        public string Director { get; set; }
        public Country Country { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [Display(Name = "Thumbnail")]
        public string ThumbnailUrl { get; set; }
        [Required]
        public string Synopsis { get; set; }
        public List<Watchlist> Watchlists { get; set; }
    }
}
