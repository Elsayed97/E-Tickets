using E_Tickets.Data.Base;
using E_Tickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor> , IActorsService
    {

        public ActorsService(AppDbContext context) : base(context)
        {
        }

        
    }
}
