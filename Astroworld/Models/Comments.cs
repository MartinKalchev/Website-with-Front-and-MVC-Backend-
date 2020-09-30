using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Astroworld.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime DateAdded { get; set; }

    }
}