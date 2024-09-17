using DebateSphere.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.DAL
{
    public class AppDbContext : DbContext
    {
        // contstructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // properties
        public DbSet<User> Users { get; set; }
        public DbSet<Debate> Debates { get; set; }
        public DbSet<Argument> Arguments { get; set; }
        public DbSet<Vote> Votes { get; set; }

        // OnModelCreating method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // configuring the database schema and relationships
        }
    }
}
