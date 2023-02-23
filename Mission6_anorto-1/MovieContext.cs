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
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating (ModelBuilder mb)
        {
            mb.Entity<MovieRecord>().HasData(
                new MovieRecord
                {
                    MovieId = 1,
                    Title = "Tarzan",
                    CategoryId = 1,
                    Director = "Don't know",
                    Rating = "PG",
                    Year = 2004,
                    Edited = false,
                    LentTo = "",
                    Notes = "",
                }
            );

            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryTitle = "Disney / Animated",
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryTitle = "Action",
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryTitle = "Comedy",
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryTitle = "Romance",
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryTitle = "Mystery",
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryTitle = "Horror",
                }
            );
        }
    }
}
