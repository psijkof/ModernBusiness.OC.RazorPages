using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchardCore;
using OrchardCore.ContentManagement;
using OrchardCore.Contents;

namespace ModernBusiness.Pages.Static
{
    [Authorize()]
    public class Full_WidthModel : PageModel
    {
        private readonly IOrchardHelper _orchardCore;
        private readonly IAuthorizationService _authorizationService;

        public Full_WidthModel(IOrchardHelper orchardCore, IAuthorizationService authorizationService)
        {
            _orchardCore = orchardCore;
            _authorizationService = authorizationService;
          
        }

        public ContentItem HeaderInfo { get; private set; }

        public async Task<IActionResult> OnGet()
        {
            //var authorized = await _authorizationService.AuthorizeAsync(User, Permissions.ViewContent);
            //if (!authorized)
            //{
            //    return Unauthorized();
            //}
            HeaderInfo = await _orchardCore.GetContentItemByAliasAsync("alias:fullwidth");

            return Page();
        }
    }
}