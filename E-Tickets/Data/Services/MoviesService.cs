using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Tickets.Models;
using E_Tickets.Data.Base;
using Microsoft.EntityFrameworkCore;
using E_Tickets.Data.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace E_Tickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie> , IMoviesService
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public MoviesService(AppDbContext context,IMapper mapper) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task AddNewMovieAsync(MovieVM movieVM)
        {
            var movie = mapper.Map<Movie>(movieVM);

            await context.Movies.AddAsync(movie);
            await context.SaveChangesAsync();

            foreach(var actorId in movieVM.ActorIds)
            {
                var actor_movie = new Actor_Movie()
                {
                    MovieId = movie.Id,
                    ActorId = actorId
                };
                await context.Actors_Movies.AddAsync(actor_movie);
            }
            await context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int Id)
        {
            var movieDetails = await context.Movies
                              .Include(m => m.Cinema)
                              .Include(m => m.Producer)
                              .Include(am => am.Movie_Actors)
                              .ThenInclude(m => m.Actor)
                              .FirstOrDefaultAsync(m => m.Id == Id);

            return movieDetails;            
        }

        public async Task<MovieDropDownVM> GetMovieDropDownValues()
        {
            MovieDropDownVM movieDropDown = new MovieDropDownVM()
            {
                Actors = await context.Actors.OrderBy(a => a.FullName).ToListAsync(),
                Cinemas = await context.Cinemas.OrderBy(c => c.Name).ToListAsync(),
                Producers = await context.Producers.OrderBy(p => p.FullName).ToListAsync()
            };

            return movieDropDown;
        }

        public async Task UpdateMovieAsync(MovieVM movieVM)
        {
            var movie = mapper.Map<Movie>(movieVM);

            //Update Movie
            if(movie != null)
            {
                EntityEntry entityEntry = context.Entry(movie);
                entityEntry.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }

            //Removing Existing Actors 
            var existedActors = context.Actors_Movies.Where(am => am.MovieId == movie.Id).ToList();
            context.Actors_Movies.RemoveRange(existedActors);
            await context.SaveChangesAsync();


            //Add Movie Actors
            foreach (var actorId in movieVM.ActorIds)
            {
                var actor_movie = new Actor_Movie()
                {
                    MovieId = movie.Id,
                    ActorId = actorId
                };
                await context.Actors_Movies.AddAsync(actor_movie);
            }
            await context.SaveChangesAsync();
        }
    }
}
