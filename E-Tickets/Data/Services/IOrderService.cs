using E_Tickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Data.Services
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShoopingCartItem> items, string userId, string userEmailAddress);
        Task <List<Order>> GetOrdersByUserIdAsync(string userId);
    }
}
