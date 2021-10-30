using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
