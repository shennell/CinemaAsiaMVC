using System;
using System.Collections.Generic;
using System.Text;
using CinemaAsia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaAsia.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Movie>()
                .HasMany(w => w.Watchlists)
                .WithOne(m => m.Movie)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .HasMany(w => w.Watchlists)
                .WithOne(u => u.User)
                .IsRequired();

            base.OnModelCreating(builder);
        }

    }
}
