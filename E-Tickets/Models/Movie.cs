using E_Tickets.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //Relationships
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public List<Actor_Movie> Movie_Actors { get; set; }
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }

    }
}
