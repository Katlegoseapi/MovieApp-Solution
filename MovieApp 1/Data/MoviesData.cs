using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Models
{
    public class MoviesData : DbContext
    {
        public MoviesData (DbContextOptions<MoviesData> options)
            : base(options)
        {
        }

        public DbSet<Movies.Models.Actor> Actor { get; set; }

        public DbSet<Movies.Models.Character> Character { get; set; }

        public DbSet<Movies.Models.Genre> Genre { get; set; }

        public DbSet<Movies.Models.Movie> Movie { get; set; }
    }
}
