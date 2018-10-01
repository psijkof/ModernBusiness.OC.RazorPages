using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModernBusiness.Pages.Shared.ViewModels;
using OrchardCore;
using OrchardCore.ContentManagement;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.Navigation;

namespace ModernBusiness.Pages.Pages
{
    public class portfolioModel : PageModel
    {
        private readonly IOrchardHelper _orchard;
        public readonly PagerInfo PagerInfo;
        public ContentItem Portfolio;

        public portfolioModel(IOrchardHelper orchard)
        {
            _orchard = orchard;

            Portfolio = _orchard.GetRecentContentItemsByContentTypeAsync("Portfolio").GetAwaiter().GetResult().First();
            PagerInfo = new PagerInfo
            {
                PageSize = 6,
                PageBaseUrl = "/portfolio"
            };
            PagerInfo.TotalPages = (
                (int)Math.Ceiling(_orchard.QueryContentItemsAsync(q => q.Where(c => c.ContentType == "Project" && c.Published))
                        .GetAwaiter().GetResult().Count() / (double)PagerInfo.PageSize));

        }

        public void OnGet(int? pageIndex)
        {
            PagerInfo.CurrentItemsOnPage =
                PagerInfo.CurrentItemsOnPage = _orchard.QueryContentItemsAsync(
                    q => q.Where(c => c.ContentType == "Project" && c.Published)
                        .Skip(((pageIndex ?? 1) - 1) * PagerInfo.PageSize)
                        .Take(PagerInfo.PageSize)).GetAwaiter().GetResult();

            PagerInfo.CurrentPage = pageIndex ?? 1;

        }

    }
}