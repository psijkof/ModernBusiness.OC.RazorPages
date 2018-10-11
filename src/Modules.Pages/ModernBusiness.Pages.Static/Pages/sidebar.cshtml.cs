using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchardCore;
using OrchardCore.ContentManagement;

namespace ModernBusiness.Pages.Static
{
    public class sidebarModel : PageModel
    {
        private readonly IOrchardHelper _orchardHelper;

        public sidebarModel(IOrchardHelper orchardHelper)
        {
            _orchardHelper = orchardHelper;
        }

        public ContentItem SideBarInfo { get; private set; }

        public async void OnGet()
        {
            SideBarInfo = await _orchardHelper.GetContentItemByAliasAsync("alias:sidebar");
        }
    }
}