using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Coding_Challenge_9_Question_2.Models
{
    public class Movies
    {
        [Key]
        public int MID { get; set; }
        public string MovieName { get; set; }
        public string DirectorName { get; set; }
        public DateTime DateofRelease { get; set; }
    }
}