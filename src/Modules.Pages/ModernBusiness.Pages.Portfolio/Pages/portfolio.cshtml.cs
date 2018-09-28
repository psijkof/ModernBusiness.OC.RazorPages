using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModernBusiness.Pages.Shared.Services;
using ModernBusiness.Pages.Shared.ViewModels;
using OrchardCore;
using OrchardCore.ContentManagement;

namespace ModernBusiness.Pages.Pages
{
    public class portfolioModel : PageModel
    {
        public PaginatedList<ContentItem> PagedList { get; set; }

        private readonly IOrchardHelper _orchard;
        public IEnumerable<ContentItem> Portfolio;
        private readonly PagerInfo _pagerInfo;

        public portfolioModel(IOrchardHelper orchard)
        {
            _orchard = orchard;
            var temp = _orchard.QueryContentItemsAsync(q => q.Where(c => c.ContentType == "Project" && c.Published)).GetAwaiter().GetResult().Count() / 6 +1;
//            _pagerInfo = new PagerInfo() { PageBaseUrl = "/portfolio", TotalPages = _portfolio.Count() };
        }

        public void OnGet(int? pageIndex)
        {
            Portfolio = _orchard.QueryContentItemsAsync(q => q.Where(c => c.ContentType == "Project" && c.Published).Skip(((pageIndex ?? 1) - 1) * 6).Take(6)).GetAwaiter().GetResult();

 //           PagedList = PaginatedList<ContentItem>.Create(_portfolio.ToList(), pageIndex ?? 1, 6);

        }
    }
}