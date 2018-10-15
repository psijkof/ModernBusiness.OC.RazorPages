using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using ModernBusiness.Pages.Shared.Services;
using OrchardCore.Modules;

namespace ModernBusiness.Pages.Shared
{
    public class Startup : StartupBase
    {

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<DataRetriever>();
        }
    }
}