using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibParts.Models
{
    public class Project
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PartInstance> Parts { get; set; }
        public ICollection<ProjectNote> Notes { get; set; }
    }
}