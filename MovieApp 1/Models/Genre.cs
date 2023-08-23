using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        public string GenreName { get; set; }
    }
}