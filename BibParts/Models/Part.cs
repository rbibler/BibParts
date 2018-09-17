using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibParts.Models
{
    public class Part
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public int? ManufacturerId { get; set; }
        public ICollection<PartInstance> Instances { get; set; }
        public ICollection<PartAttribute> Attributes { get; set; }
    }
}