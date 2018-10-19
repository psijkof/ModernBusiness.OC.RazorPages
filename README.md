# ModernBusiness.OC.RazorPages
Start Bootstrap's Modern Business Theme for Orchard Core as a decoupled Razor Pages Module

## Setup
Need to git clone https://github.com/BlackrockDigital/startbootstrap-modern-business into src/Themes.Pages/ModernBusiness.Theme/wwwroot/


## Some things to note
- Your modules project (.csproj) files, if using the Razor Pages framework, should be using the Razor sdk, like so:
`<Project Sdk="Microsoft.NET.Sdk.Razor">`
- To have easy access to the OrchardHelper and related Orchard services, make sure your Razor Pages inherit from OrchardCore.DisplayManagement.RazorPages.Page like so `@inherits OrchardCore.DisplayManagement.RazorPages.Page`. This is done in _ViewImports.cshtml. This counts for razor views like partials as well, except, you inherit from OrchardCore.DisplayManagement.Razor.RazorPage<TModel> like so `@inherits OrchardCore.DisplayManagement.Razor.RazorPage<TModel>`
- In most modules, besides referencing `OrchardCore.Module.Targets`, you will want to reference `OrchardCore.DisplayManagement`, `OrchardCore.Media`, `OrchardCore.ContentManagement`, `OrchardCore.Content` and `OrchardCore.ResourceManagement`
- Every Razor Pages module needs a to add an AreaFolderRoute if it wants to be able to respond to requests. For example like: 
```
  services.Configure<RazorPagesOptions>(options =>
    {
        options.Conventions.AddAreaFolderRoute("ModernBusiness.Pages.Portfolio", "/", "");
    });
```
- The _ViewStart of each module points to "Layout". The Layout will be resolved from the .Theme module, from `Views\Shared`. 
- For the `NotFound.cshtml` (for 404 status cases), the Layout will be resolved from `Views`, as this is OC's default Layout location.
 
