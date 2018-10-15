using ModernBusiness.Pages.Shared.ViewModels;
using OrchardCore;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ModernBusiness.Pages.Shared.Services
{
    public class DataRetriever
    {
        private PagerInfo _pagerInfo;
        private readonly IOrchardHelper _orchard;

        public DataRetriever(IOrchardHelper orchard)
        {
            _orchard = orchard;
        }

        public async Task<PagerInfo> InitializePager(int pageSize, string baseUrl, string listItemsContentType)
        {
            _pagerInfo = new PagerInfo
            {
                PageSize = pageSize,
                PageBaseUrl = baseUrl,
                ItemsContentType = listItemsContentType
            };

            var itemsCount = await _orchard.QueryContentItemsAsync(q => q.Where(c => c.ContentType == listItemsContentType && c.Published));

            _pagerInfo.TotalPages = (int)Math.Ceiling(itemsCount.Count() / (double)_pagerInfo.PageSize);

            return _pagerInfo;
        }

        public async Task<ContentItem> InitializeContainer(string containerContentType)
        {
            return (await _orchard.GetRecentContentItemsByContentTypeAsync(containerContentType)).FirstOrDefault();
        }

        public async Task<IEnumerable<ContentItem>> GetCurrentPage()
        {
            return _pagerInfo.CurrentItemsOnPage = await _orchard.QueryContentItemsAsync(
                    q => q.Where(c => c.ContentType == _pagerInfo.ItemsContentType && c.Published)
                    .OrderByDescending(o => o.PublishedUtc)
                        .Skip(((_pagerInfo.CurrentPage) - 1) * _pagerInfo.PageSize)
                        .Take(_pagerInfo.PageSize));
        }

    }
}
