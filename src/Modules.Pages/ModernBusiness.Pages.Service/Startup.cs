using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;

namespace ModernBusiness.Pages.Service
{
    public class Startup : StartupBase
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RazorPagesOptions>(options =>
            {
                options.Conventions.AddAreaFolderRoute("ModernBusiness.Pages.Service", "/", "");
            });
        }
    }
}
