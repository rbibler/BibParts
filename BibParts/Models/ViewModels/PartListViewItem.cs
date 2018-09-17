using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibParts.Models
{
    public class PartListViewItem
    {
        public Part PartItem { get; set; }
        public string CategoryName { get; set; }
        public int TotalNumber { get; set; }
        public int NumberInUse { get; set; }

    }
}