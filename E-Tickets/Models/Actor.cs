﻿using E_Tickets.Data.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Models
{
    public class Actor : IEntityBase
    {
        [Key] //Optional
        public int Id { get; set; }
        
        [Display(Name ="Profile Picture URL")]
        [Required(ErrorMessage ="Profile Picture URL is Required")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name ="Full Name")]
        [Required(ErrorMessage = "Full Name is Required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Full Name Must be between 3 and 50 chars")]
        public string FullName { get; set; }

        [Display(Name ="Biography")]
        [Required(ErrorMessage = "Biography is Required")]
        public string Bio { get; set; }

        //Relationships
        public List<Actor_Movie> Movie_Actors { get; set; }
    }
}
