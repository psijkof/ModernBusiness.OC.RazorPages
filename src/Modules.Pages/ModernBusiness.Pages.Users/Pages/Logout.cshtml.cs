using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchardCore.Users;

namespace ModernBusiness.Pages.Users.Pages
{
    public class LogoutModel : PageModel
    {
		private readonly SignInManager<IUser> _signinManager;

		public LogoutModel(SignInManager<IUser> signinManager)
		{
			_signinManager = signinManager;
		}

        public async Task<IActionResult> OnGetAsync()
        {
			await _signinManager.SignOutAsync();

			return LocalRedirect("~/");
        }
    }
}