using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Tickets.Models
{
    public class Actor_Movie

    {
        //Relationships
        public int MovieId { get; set; }

        [ForeignKey(name:"MovieId")]  //optional
        public Movie Movie { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
