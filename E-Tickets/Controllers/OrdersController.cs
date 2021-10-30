using E_Tickets.Data.Cart;
using E_Tickets.Data.Services;
using E_Tickets.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMoviesService moviesService;
        private readonly ShoopingCart shoopingCart;
        private readonly IOrderService orderService;

        public OrdersController(IMoviesService moviesService
                                ,ShoopingCart shoopingCart
                                ,IOrderService orderService)
        {
            this.moviesService = moviesService;
            this.shoopingCart = shoopingCart;
            this.orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = "";
            var orders = await orderService.GetOrdersByUserIdAsync(userId);
            return View(orders);
        }

        public IActionResult ShoopingCart()
        {
            var shoopingCartItems = shoopingCart.GetShoopingCartItems();
            shoopingCart.ShoopingCartItems = shoopingCartItems;
            var response = new ShoopingCartVM()
            {
                ShoopingCart = shoopingCart,
                ShoopingCartTotal = shoopingCart.GetShoopingCartTotal()
            };
            return View(response);
        }

        public async Task<RedirectToActionResult> AddItemsToShoopingCart(int id)
        {
            var item = await moviesService.GetMovieByIdAsync(id);
            if(item != null)
            {
                shoopingCart.AddItemsToCart(item);
            }
            return RedirectToAction("ShoopingCart");
        }

        public async Task<IActionResult> AddItemToShoopingCart(int id)
        {
            var item = await moviesService.GetMovieByIdAsync(id);
            if(item != null)
            {
                shoopingCart.AddItemsToCart(item);
            }
            return RedirectToAction("ShoopingCart");
        }


        public async Task<IActionResult> RemoveItemFromShoopingCart(int id)
        {
            var item = await moviesService.GetMovieByIdAsync(id);
            if (item != null)
            {
                shoopingCart.RemoveItemsFromCart(item);
            }
            return RedirectToAction("ShoopingCart");
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = shoopingCart.GetShoopingCartItems();
            string userId = "";
            string emailAddress = "";

            await orderService.StoreOrderAsync(items, userId, emailAddress);
            await shoopingCart.ClearShoopingCartAsync();
            return View("OrderCompleted");
        }
    }
}
