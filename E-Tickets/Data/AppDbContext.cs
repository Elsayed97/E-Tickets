using E_Tickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.MovieId,
                am.ActorId
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie)
                .WithMany(am => am.Movie_Actors)
                .HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<Actor_Movie>().HasOne(a => a.Actor)
                .WithMany(am => am.Movie_Actors)
                .HasForeignKey(a => a.ActorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoopingCartItem> ShoopingCartItems { get; set; }
    }
}
