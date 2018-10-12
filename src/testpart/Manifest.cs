using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "TestTagPart.OrchardCore",
    Author = "The Orchard Team",
    Website = "http://orchardproject.net",
    Version = "0.0.1",
    Description = "TestTagPart.OrchardCore",
    Dependencies = new[] { "OrchardCore.Contents" },
    Category = "Content Management"
)]
