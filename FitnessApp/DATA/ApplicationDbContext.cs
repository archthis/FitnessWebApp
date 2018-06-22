using FitnessAPP.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessAPP.DATA
{
    public class ApplicationDbContext : DbContext
    {
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=thefdb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
       
        public DbSet<Models.Activity> Activities { get; set; }
        public DbSet<Models.Entry> Entries { get; set; }

  
    }
}
