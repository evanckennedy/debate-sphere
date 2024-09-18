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
            // Users Table
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserID);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            // Debates Table
            modelBuilder.Entity<Debate>()
                .HasKey(d => d.DebateID);

            modelBuilder.Entity<Debate>()
                .HasOne(d => d.User)
                .WithMany(u => u.Debates)
                .HasForeignKey(d => d.CreatedBy);

            modelBuilder.Entity<Debate>()
                .Property(d => d.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            // Arguments Table
            modelBuilder.Entity<Argument>()
                .HasKey(a => a.ArgumentID);

            modelBuilder.Entity<Argument>()
                .HasOne(a => a.Debate)
                .WithMany(d => d.Arguments)
                .HasForeignKey(a => a.DebateID);

            modelBuilder.Entity<Argument>()
                .HasOne(a => a.User)
                .WithMany(u => u.Arguments)
                .HasForeignKey(a => a.PostedBy);

            modelBuilder.Entity<Argument>()
                .Property(a => a.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            // Votes Table
            modelBuilder.Entity<Vote>()
                .HasKey(v => v.VoteID);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Debate)
                .WithMany(d => d.Votes)
                .HasForeignKey(v => v.DebateID);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.User)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.VoterID);

            modelBuilder.Entity<Vote>()
                .HasIndex(v => new { v.DebateID, v.VoterID })
                .IsUnique();

            modelBuilder.Entity<Vote>()
               .Property(v => v.CreatedAt)
               .HasDefaultValueSql("GETDATE()");
        }
    }
}
