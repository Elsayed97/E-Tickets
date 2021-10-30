using E_Tickets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Data.Cart
{
    public class ShoopingCart
    {
        public AppDbContext context { get; set; }
        public string shoopingCartId { get; set; }
        public List<ShoopingCartItem> ShoopingCartItems { get; set; }

        public ShoopingCart(AppDbContext context)
        {
            this.context = context;
        }

        public List<ShoopingCartItem> GetShoopingCartItems()
        {
            return ShoopingCartItems ?? (context.ShoopingCartItems.Where(n => 
                                         n.ShoopingCartId == shoopingCartId).Include(n => n.Movie).ToList());
        }

        public double GetShoopingCartTotal()
        {
            return context.ShoopingCartItems.Where(n => n.ShoopingCartId == shoopingCartId)
                          .Select(n => n.Movie.Price * n.Amount).Sum();
        }

        public void AddItemsToCart(Movie movie)
        {
            var shoopingCartItem = context.ShoopingCartItems.FirstOrDefault(n => 
                                               n.Movie.Id == movie.Id && n.ShoopingCartId == shoopingCartId);
            if(shoopingCartItem == null)
            {
                shoopingCartItem = new ShoopingCartItem()
                {
                    ShoopingCartId = shoopingCartId,
                    Movie = movie,
                    Amount = 1
                };

                context.ShoopingCartItems.Add(shoopingCartItem);
            }
            else
            {
                shoopingCartItem.Amount++;
            }
            context.SaveChanges();
        }

        public void RemoveItemsFromCart(Movie movie)
        {
            var shoopingCartItem = context.ShoopingCartItems.FirstOrDefault(n =>
                                                     n.Movie.Id == movie.Id && n.ShoopingCartId == shoopingCartId);
            if(shoopingCartItem != null)
            {
                if(shoopingCartItem.Amount > 1)
                {
                    shoopingCartItem.Amount--;
                }
                else
                {
                    context.ShoopingCartItems.Remove(shoopingCartItem);
                }
                context.SaveChanges();
            }
        }

        public static ShoopingCart GetShoopingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetRequiredService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId",cartId);

            return new ShoopingCart(context) { shoopingCartId = cartId };
        }

        public async Task ClearShoopingCartAsync()
        {
            var items = await context.ShoopingCartItems.Where(n => n.ShoopingCartId == shoopingCartId).ToListAsync();
            context.ShoopingCartItems.RemoveRange(items);
            await context.SaveChangesAsync();
        }
    }
}
