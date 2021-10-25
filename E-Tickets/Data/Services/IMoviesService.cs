using E_Tickets.Data.Base;
using E_Tickets.Data.ViewModels;
using E_Tickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int Id);
        Task<MovieDropDownVM> GetMovieDropDownValues();
        Task AddNewMovieAsync(MovieVM movie);
        Task UpdateMovieAsync(MovieVM movie);
    }
}
