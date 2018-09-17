using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibParts.Models
{
    public class ProjectNote
    {

        public int Id { get; set; }
        public string NoteBody { get; set; }
        public int ProjectId { get; set; }

    }
}