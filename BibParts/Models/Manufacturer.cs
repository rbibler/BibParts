using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibParts.Models
{
    public class Manufacturer
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Part> Parts { get; set; }

    }
}