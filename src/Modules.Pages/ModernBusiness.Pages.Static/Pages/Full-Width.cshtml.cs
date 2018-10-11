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
    public class Full_WidthModel : PageModel
    {
        private readonly IOrchardHelper _orchardCore;

        public Full_WidthModel(IOrchardHelper orchardCore)
        {
            _orchardCore = orchardCore;
        }

        public ContentItem HeaderInfo { get; private set; }

        public async void OnGet()
        {
            HeaderInfo = await _orchardCore.GetContentItemByAliasAsync("alias:fullwidth");

        }
    }
}