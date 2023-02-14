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
    }
}
