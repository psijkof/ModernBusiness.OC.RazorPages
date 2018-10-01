using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchardCore;
using OrchardCore.ContentManagement;

namespace ModernBusiness.Pages.Pages
{
    public class projectModel : PageModel
    {
        private readonly IOrchardHelper _orchardHelper;
        public dynamic Project { get; private set; }

        public projectModel(IOrchardHelper orchardHelper)
        {
            _orchardHelper = orchardHelper;
        }


        public void OnGet(string projectTitle)
        {
            Project = _orchardHelper.QueryContentItemsAsync(q=>q.Where(c=>c.DisplayText==projectTitle))
                .GetAwaiter().GetResult().SingleOrDefault();

        }
    }
}