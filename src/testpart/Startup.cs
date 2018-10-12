using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Data.Migration;
using TestTagPart.OrchardCore.Drivers;
using TestTagPart.OrchardCore.Handlers;
using TestTagPart.OrchardCore.Models;
using TestTagPart.OrchardCore.Settings;
using OrchardCore.Modules;
using OrchardCore.Indexing;
using TestTagPart.OrchardCore.Indexing;

namespace TestTagPart.OrchardCore
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IContentPartDisplayDriver, TestTagPartPartDisplayDriver>();
            services.AddSingleton<ContentPart, TestTagPartPart>();
            services.AddScoped<IContentPartDefinitionDisplayDriver, TestTagPartPartSettingsDisplayDriver>();
			services.AddScoped<IContentPartIndexHandler, TestTagPartIndexHandler>();
            services.AddScoped<IDataMigration, Migrations>();
            services.AddScoped<IContentPartHandler, TestTagPartPartHandler>();
        }

        public override void Configure(IApplicationBuilder builder, IRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaRoute(
                name: "Home",
                areaName: "TestTagPart.OrchardCore",
                template: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}