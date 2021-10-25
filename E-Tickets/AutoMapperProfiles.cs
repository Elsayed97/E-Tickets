using AutoMapper;
using E_Tickets.Data.ViewModels;
using E_Tickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieVM, Movie>();
            CreateMap<Movie, MovieVM>();
        }
    }
}
