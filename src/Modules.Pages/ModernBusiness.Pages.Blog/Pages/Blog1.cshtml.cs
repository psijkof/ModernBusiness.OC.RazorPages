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

namespace ModernBusiness.Pages.Blog.Pages
{
    public class Blog1Model : PageModel
    {
        private readonly IOrchardHelper _orchard;
        public  PagerInfo PagerInfo;
        public ContentItem Blog;
        public dynamic BlogPostTitle { get; private set; }
        public dynamic BlogPost;
        private readonly DataRetriever _dataRetriever;

        public Blog1Model(IOrchardHelper orchard, DataRetriever dataRetriever)
        {
            _orchard = orchard;
            _dataRetriever = dataRetriever;
        }

        public async Task OnGetAsync(int? pageIndex, string BlogPostTitle)
        {
            if (string.IsNullOrEmpty(BlogPostTitle))
            {
                Blog = await _dataRetriever.InitializeContainer("Blog");
                PagerInfo = await _dataRetriever.InitializePager(3, "/blog1", "BlogPost");
                PagerInfo.CurrentPage = pageIndex ?? 1;
                PagerInfo.CurrentItemsOnPage = await _dataRetriever.GetCurrentPage();
            }
            else
            {
                BlogPost = (await _orchard.QueryContentItemsAsync(q => q.Where(c => c.DisplayText == BlogPostTitle && c.Published))).SingleOrDefault();
            }
        }
    }
}