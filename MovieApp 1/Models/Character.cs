using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class Character
    {
        public int MovieID { get; set; }
        public Movie Movie { get; set; }

        public int ActorID { get; set; }
        public Actor Actor { get; set; }

        [Key]
        [Column(TypeName = "nvarchar(50)")]
        public string CharacterName { get; set; }
    }
}