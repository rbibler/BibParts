using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibParts.Models
{
    public class PartInstanceNote
    {

        public int Id { get; set; }
        public int PartInstanceId { get; set; }
        public string NoteBody { get; set; }

    }
}