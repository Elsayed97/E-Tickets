
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext context;

        public EntityBaseRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await context.Set<T>().ToListAsync();
            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
            return result;
        }

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry =  context.Entry<T>(entity);
            entityEntry.State =  EntityState.Modified;
            await context.SaveChangesAsync();

        }
    }
}
