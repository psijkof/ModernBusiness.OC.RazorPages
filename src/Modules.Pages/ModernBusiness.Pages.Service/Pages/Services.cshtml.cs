using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchardCore;
using OrchardCore.Contents;

namespace ModernBusiness.Pages.Service
{
    public class ServicesModel : PageModel
    {
        private readonly IOrchardHelper _orchardHelper;
        public dynamic ServicesContainer { get; private set; }
        public dynamic ServicesList { get; private set; }

        public ServicesModel(IOrchardHelper orchardHelper)
        {
            _orchardHelper = orchardHelper;
            ServicesContainer = orchardHelper.GetRecentContentItemsByContentTypeAsync("Services").GetAwaiter().GetResult().SingleOrDefault();
            ServicesList = orchardHelper.GetRecentContentItemsByContentTypeAsync("Service").GetAwaiter().GetResult().OrderByDescending(c => c.CreatedUtc).Take(3);
        }

        public void OnGet()
        {
        }
    }
}