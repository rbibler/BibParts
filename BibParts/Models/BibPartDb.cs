using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BibParts.Models
{
    public class BibPartDb : DbContext
    {
        public DbSet<Part> Parts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PartInstance> PartInstances { get; set; }
        public DbSet<PartInstanceNote> PartInstanceNotes { get; set; }
        public DbSet<ProjectNote> ProjectNotes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<PartAttribute> PartAttributes { get; set; }


    }
}