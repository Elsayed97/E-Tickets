using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Models
{
    public class Cinema
    {
        public int Id { get; set; }

        [Display(Name="Cinema Logo")]
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
