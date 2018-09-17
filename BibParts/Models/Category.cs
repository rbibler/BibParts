using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibParts.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Part> Parts { get; set; }
    }
}