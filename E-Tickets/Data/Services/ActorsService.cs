using E_Tickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext context;

        public ActorsService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Actor actor)
        {
            await context.Actors.AddAsync(actor);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var actor = await context.Actors.FirstOrDefaultAsync(a => a.Id == id);
            context.Actors.Remove(actor);
            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await context.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await context.Actors.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            context.Update(newActor);
            await context.SaveChangesAsync();
            return newActor;
        }
    }
}
