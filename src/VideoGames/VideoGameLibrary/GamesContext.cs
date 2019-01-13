using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;



namespace VideoGameLibrary
{
    public class GamesContext : DbContext
    {
       public GamesContext(DbContextOptions<GamesContext> options) :base(options)
        {

        }

        public DbSet<Games> Games { get; set; }
        public DbSet<Company> Company { get; set; }
    }
}
