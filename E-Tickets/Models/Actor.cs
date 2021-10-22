﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Models
{
    public class Actor
    {
        [Key] //Optional
        public int Id { get; set; }
        
        [Display(Name ="Profile Picture URL")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name ="Full Name")]
        public string FullName { get; set; }

        [Display(Name ="Biography")]
        public string Bio { get; set; }

        //Relationships
        public List<Actor_Movie> Movie_Actors { get; set; }
    }
}
