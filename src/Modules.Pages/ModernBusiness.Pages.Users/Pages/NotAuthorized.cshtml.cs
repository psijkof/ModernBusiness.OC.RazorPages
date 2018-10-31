using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchardCore;
using OrchardCore.ContentManagement;

namespace ModernBusiness.Pages.Users.Pages
{
    public class NotAuthorizedModel : PageModel
    {
		private readonly IOrchardHelper _orchardHelper;

		public ContentItem UnauthorizedCI { get; set; }

		public NotAuthorizedModel(IOrchardHelper orchardHelper)
		{
			_orchardHelper = orchardHelper;
		}

        public async void OnGetAsync()
        {
			UnauthorizedCI = await _orchardHelper.GetContentItemByAliasAsync("alias:unauthorized");
        }
    }
}