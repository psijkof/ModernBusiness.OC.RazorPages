using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using OrchardCore;
using OrchardCore.ContentManagement;

namespace ModernBusiness.Pages.Pages
{
    public class projectModel : PageModel
    {
        private readonly IOrchardHelper _orchardHelper;
        public dynamic Project { get; private set; }

        public IEnumerable<ContentItem> RelatedProjects { get; private set; }

        public projectModel(IOrchardHelper orchardHelper)
        {
            _orchardHelper = orchardHelper;
        }

        public async Task OnGetAsync(string projectTitle)
        {

            Project = _orchardHelper.QueryContentItemsAsync(q => q.Where(c => c.DisplayText == projectTitle))
                .GetAwaiter().GetResult().SingleOrDefault();

            var relatedProjects = (IEnumerable<string>)Project?.Content.Project.RelatedProjects?.ContentItemIds?.ToObject<string[]>();

            if (relatedProjects?.Count() > 0)
            {
                RelatedProjects = await
                    _orchardHelper.GetContentItemsByIdAsync(relatedProjects);
            }
        }
    }
}