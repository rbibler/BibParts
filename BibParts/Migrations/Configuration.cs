namespace BibParts.Migrations
{
    using BibParts.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<BibParts.Models.BibPartDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BibParts.Models.BibPartDb";
        }

        protected override void Seed(BibParts.Models.BibPartDb context)
        {

            // Setup some instance notes
            var instanceNote1 = new PartInstanceNote { NoteBody = "This part is great!"};
            var instanceNote2 = new PartInstanceNote { NoteBody = "This part is greater!" };
            var instanceNote3 = new PartInstanceNote { NoteBody = "This part is greatest!" };
            var instanceNote4 = new PartInstanceNote { NoteBody = "This part is greatestest" };
            var instanceNote5 = new PartInstanceNote { NoteBody = "This part is greatestsetset" };

            // setup four parts, two from one category, once each from the other
            var resistor = new Part {
                Name = "Resistor",
                Instances = new List<PartInstance> {
                    new PartInstance { PartNotes = new List<PartInstanceNote> { instanceNote1 } },
                    new PartInstance { PartNotes = new List<PartInstanceNote> { instanceNote2 } },
                    new PartInstance { PartNotes = new List<PartInstanceNote> { instanceNote3 } }

                }
            };

            var capacitor = new Part {
                Name = "Capacitor",
                Instances = new List<PartInstance> {
                    new PartInstance { PartNotes = new List<PartInstanceNote> { instanceNote4  } }
                 
                }
            };

            var ic = new Part{ Name = "IC" };

            var led = new Part
            {
                Name = "led",
                Instances = new List<PartInstance> {
                    new PartInstance { PartNotes = new List<PartInstanceNote> { instanceNote5  } }


                }
            };

            // Setup a project to add some part instances to
            var project = new Project
            {
                Name = "Project One",
                Parts = new List<PartInstance> { resistor.Instances.First() },
                Notes = new List<ProjectNote> { new ProjectNote { NoteBody = "THIS IS A PROJECT!" } }
            };

            // Create a manufacturer, and give it all the parts
            var manufacturer = new Manufacturer { Name = "Manufacturer",
                Parts = new List<Part> { resistor, capacitor, ic, led }
            };

            // Add the manufacturer, categories, and project to the DB
            context.Manufacturers.AddOrUpdate(m => m.Name,
                manufacturer
            );

            context.Projects.AddOrUpdate(p => p.Name,
                project
            );

           
            context.Categories.AddOrUpdate(c => c.Name,
                new Category { Name = "Optoelectrics", Parts = new List<Part> { led } },
                new Category { Name = "Semiconductors", Parts = new List<Part> { ic } },
                new Category { Name = "Passives", Parts = new List<Part> { resistor, capacitor } });
        }
    }
}
