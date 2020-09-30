using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Astroworld.Models
{
    public class CommentsContext : DbContext
    {
        public CommentsContext()
            : base("Comments")
        {
       
        }
        public DbSet<Comments> Entries { get; set; }
    }
}