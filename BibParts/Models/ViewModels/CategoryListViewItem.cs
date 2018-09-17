using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibParts.Models
{
    public class CategoryListViewItem
    {

        public int CategoryId { get; set; }
        public int PartsCount { get; set; }
        public string CategoryName { get; set; }
    }
}