using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class Actor
    {
        [Key]
        public int ActorID { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        public string ActorName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ActorDOB { get; set; }
    }
}