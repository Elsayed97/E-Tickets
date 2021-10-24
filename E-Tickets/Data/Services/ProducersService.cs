using E_Tickets.Data.Base;
using E_Tickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer> , IProducersService
    {
        public ProducersService(AppDbContext context):base(context)
        {
        }
    }
}
