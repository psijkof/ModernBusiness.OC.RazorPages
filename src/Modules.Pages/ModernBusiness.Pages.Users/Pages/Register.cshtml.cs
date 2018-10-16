using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModernBusiness.Pages.Users.ViewModels;

namespace ModernBusiness.Pages.Users.Pages
{
    public class RegisterModel : PageModel
    {
		[BindProperty]
		public RegisterViewModel RegisterVM { get; set; }

		public RegisterModel()
		{
			// Next thing to do
		}

        public void OnGet()
        {
        }
    }
}