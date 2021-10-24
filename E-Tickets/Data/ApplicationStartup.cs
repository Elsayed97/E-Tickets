﻿using E_Tickets.Data.Base;
using E_Tickets.Data.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Data
{
    public static class ApplicationStartup
    { 
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IActorsService, ActorsService>();
            services.AddScoped<IProducersService, ProducersService>();
            return services;
        }
    }
}
