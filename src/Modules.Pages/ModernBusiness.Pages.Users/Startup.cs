using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using OrchardCore.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ModernBusiness.Pages.Users
{
	public class Startup : StartupBase
	{
		public override void ConfigureServices(IServiceCollection services)
		{
			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/Login";
			});

			services.Configure<RazorPagesOptions>(options =>
			{
				options.Conventions.AddAreaFolderRoute("ModernBusiness.Pages.Users", "/", "");
			});
		}

	}
}
