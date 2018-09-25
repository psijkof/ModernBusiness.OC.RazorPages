using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;

namespace ModernBusiness.Pages
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RazorPagesOptions>(options =>
            {
                options.Conventions.AddAreaFolderRoute("ModernBusiness.Pages", "/", "");
            });
        }
    }
}