﻿using E_Tickets.Data.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
       
    }
}
