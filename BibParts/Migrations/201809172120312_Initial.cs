namespace BibParts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(),
                        ManufacturerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId)
                .Index(t => t.CategoryId)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.PartAttributes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AttributeTypeId = c.Int(nullable: false),
                        Name = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PartInstances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartId = c.Int(nullable: false),
                        InUse = c.Boolean(nullable: false),
                        ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.PartId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.PartInstanceNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartInstanceId = c.Int(nullable: false),
                        NoteBody = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PartInstances", t => t.PartInstanceId, cascadeDelete: true)
                .Index(t => t.PartInstanceId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoteBody = c.String(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PartAttributeParts",
                c => new
                    {
                        PartAttribute_Id = c.Int(nullable: false),
                        Part_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PartAttribute_Id, t.Part_Id })
                .ForeignKey("dbo.PartAttributes", t => t.PartAttribute_Id, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.Part_Id, cascadeDelete: true)
                .Index(t => t.PartAttribute_Id)
                .Index(t => t.Part_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PartInstances", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectNotes", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Parts", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Parts", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.PartInstances", "PartId", "dbo.Parts");
            DropForeignKey("dbo.PartInstanceNotes", "PartInstanceId", "dbo.PartInstances");
            DropForeignKey("dbo.PartAttributeParts", "Part_Id", "dbo.Parts");
            DropForeignKey("dbo.PartAttributeParts", "PartAttribute_Id", "dbo.PartAttributes");
            DropIndex("dbo.PartAttributeParts", new[] { "Part_Id" });
            DropIndex("dbo.PartAttributeParts", new[] { "PartAttribute_Id" });
            DropIndex("dbo.ProjectNotes", new[] { "ProjectId" });
            DropIndex("dbo.PartInstanceNotes", new[] { "PartInstanceId" });
            DropIndex("dbo.PartInstances", new[] { "ProjectId" });
            DropIndex("dbo.PartInstances", new[] { "PartId" });
            DropIndex("dbo.Parts", new[] { "ManufacturerId" });
            DropIndex("dbo.Parts", new[] { "CategoryId" });
            DropTable("dbo.PartAttributeParts");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectNotes");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.PartInstanceNotes");
            DropTable("dbo.PartInstances");
            DropTable("dbo.PartAttributes");
            DropTable("dbo.Parts");
            DropTable("dbo.Categories");
        }
    }
}
