using E_Tickets.Data.Cart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Data.ViewComponents
{
    public class ShoopingCartSummary : ViewComponent
    {
        private readonly ShoopingCart shoopingCart;

        public ShoopingCartSummary(ShoopingCart shoopingCart)
        {
            this.shoopingCart = shoopingCart;
        }
        public IViewComponentResult Invoke()
        {
            var items = shoopingCart.GetShoopingCartItems();
            return View(items.Count);
        }
    }
}
