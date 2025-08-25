using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Coding_Challenge_9_Question_2.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext() : base("name=connectstr") { }
        public DbSet<Movies> Movies { get; set; }
    }

}