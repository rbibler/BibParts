using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibParts.Models
{
    public class PartAttribute
    {

        public int Id { get; set; }
        public int AttributeTypeId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public ICollection<Part> Parts { get; set; }
    }
}