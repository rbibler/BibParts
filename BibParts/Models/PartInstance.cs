using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibParts.Models
{
    public class PartInstance
    {

        public int Id { get; set; }
        public int PartId { get; set; }
        public bool InUse { get; set; }
        
        public int? ProjectId { get; set; }
        public ICollection<PartInstanceNote> PartNotes { get; set; }

    }
}