using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BibParts.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(500)]
        public string Name { get; set; }
        public virtual List<Part> Parts { get; set; }
    }
}