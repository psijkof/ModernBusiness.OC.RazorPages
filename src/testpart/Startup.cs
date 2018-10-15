using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Data.Migration;
using Tags.OrchardCore.Drivers;
using Tags.OrchardCore.Handlers;
using Tags.OrchardCore.Models;
using Tags.OrchardCore.Settings;
using OrchardCore.Modules;
using OrchardCore.Indexing;
using Tags.OrchardCore.Indexing;

namespace Tags.OrchardCore
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IContentPartDisplayDriver, TagsPartDisplayDriver>();
            services.AddSingleton<ContentPart, TagsPart>();
            services.AddScoped<IContentPartDefinitionDisplayDriver, TagsPartSettingsDisplayDriver>();
			services.AddScoped<IContentPartIndexHandler, TagsIndexHandler>();
            services.AddScoped<IDataMigration, Migrations>();
            services.AddScoped<IContentPartHandler, TagsPartHandler>();
        }

        public override void Configure(IApplicationBuilder builder, IRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaRoute(
                name: "Home",
                areaName: "Tags.OrchardCore",
                template: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}