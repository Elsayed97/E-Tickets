using E_Tickets.Data.Base;
using E_Tickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema> , ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context)
        {
        }
    }
}
