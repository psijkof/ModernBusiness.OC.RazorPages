using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModernBusiness.Pages.Shared.ViewModels;
using OrchardCore;
using OrchardCore.ContentManagement;

namespace ModernBusiness.Pages.Blog.Pages
{
    public class Blog2Model : PageModel
    {
		private readonly IOrchardHelper _orchard;
		public readonly PagerInfo PagerInfo;
		public ContentItem Blog;
		public dynamic BlogPostTitle { get; private set; }
		public dynamic BlogPost;

		public Blog2Model(IOrchardHelper orchard)
		{
			_orchard = orchard;
			Blog = _orchard.GetRecentContentItemsByContentTypeAsync("Blog").GetAwaiter().GetResult().SingleOrDefault();
			PagerInfo = new PagerInfo
			{
				PageSize = 4,
				ShowPages = false,
				PageBaseUrl = "/blog-2"
			};

			PagerInfo.TotalPages = (int)Math.Ceiling(_orchard.QueryContentItemsAsync(q => q.Where(b => b.ContentType == "BlogPost" && b.Published))
				.GetAwaiter().GetResult().Count() / (double)PagerInfo.PageSize);
		}

		public async Task OnGetAsync(int? pageIndex, string BlogPostTitle)
		{
			PagerInfo.CurrentItemsOnPage = await _orchard.QueryContentItemsAsync(q => q.Where(b => b.ContentType == "BlogPost" && b.Published)
				.Skip(((pageIndex ?? 1) - 1) * PagerInfo.PageSize).Take(PagerInfo.PageSize));

			PagerInfo.CurrentPage = pageIndex ?? 1;
			if (!string.IsNullOrEmpty(BlogPostTitle))
			{
				BlogPost = (await _orchard.QueryContentItemsAsync(q => q.Where(c => c.DisplayText == BlogPostTitle))).SingleOrDefault();
			}

		}
	}
}