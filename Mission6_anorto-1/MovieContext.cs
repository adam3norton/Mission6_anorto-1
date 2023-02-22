using Microsoft.EntityFrameworkCore;
using Mission6_anorto_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6_anorto_1
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base (options) {
            // blank for now
        }

        public DbSet<MovieRecord> Movies { get; set; }

        protected override void OnModelCreating (ModelBuilder mb)
        {
            mb.Entity<MovieRecord>().HasData(
                new MovieRecord
                {
                    MovieId = 0,
                    Title = "Tarzan",
                    CategoryId = 0,
                    Director = "Don't know",
                    Year = 2004,
                    Edited = false,
                    LentTo = "",
                    Notes = "",
                }
            );

            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 0,
                    CategoryTitle = "Disney / Animated",
                },
                new Category
                {
                    CategoryId = 1,
                    CategoryTitle = "Action",
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryTitle = "Comedy",
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryTitle = "Romance",
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryTitle = "Mystery",
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryTitle = "Horror",
                }
            );
        }
    }
}
