using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OrchardCore.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModernBusiness.Pages.Users.ViewModels;
using OrchardCore.Environment.Shell;
using OrchardCore.Users.Models;

namespace ModernBusiness.Pages.Users.Pages
{
    public class LoginModel : PageModel
    {
		[BindProperty]
		public LoginViewModel LoginVM { get; set; }

		private readonly ShellSettings _shellSettings;
		private readonly SignInManager<IUser> _signInManager;
		private readonly UserManager<IUser> _userManager;

		public LoginModel(UserManager<IUser> userManager, SignInManager<IUser> signInManager, ShellSettings shellSettings)
		{
			_shellSettings = shellSettings;
			_signInManager = signInManager;
			_userManager = userManager;
		}

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
			await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

			ViewData["ReturnUrl"] = returnUrl;

			return Page();
        }

		public async Task<IActionResult> OnPostAsync(string returnUrl)
		{


			if (ModelState.IsValid)
			{
				returnUrl = returnUrl ?? Url.Content("~/");
				//var user = await _userManager.FindByNameAsync(Login.Name) as User;

				var result = await _signInManager.PasswordSignInAsync(LoginVM.Name, LoginVM.Password, LoginVM.RememberMe, lockoutOnFailure: false);
				if (result.Succeeded)
				{
					return LocalRedirect(returnUrl);
				}
			}

			return Page();


			//returnUrl.Replace(_shellSettings.Name, "");
		}
    }
}