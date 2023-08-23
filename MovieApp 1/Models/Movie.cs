using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MovieName { get; set; }

        public int ReleaseYear { get; set; }

        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}