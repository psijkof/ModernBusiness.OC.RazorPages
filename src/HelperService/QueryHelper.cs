using System;
using System.Collections.Generic;
using System.Text;
using OrchardCore.Contents;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using System.Threading.Tasks;
using OrchardCore;

namespace HelperService
{
    public class QueryHelper
    {
        private readonly IOrchardHelper _orchardHelper;

        public QueryHelper(IOrchardHelper orchardHelper)
        {
            _orchardHelper = orchardHelper;
        }

        public async Task<IEnumerable<ContentItem>> GetPublishedContentItemsAsync(string contentType)
        {
            return await _orchardHelper.QueryContentItemsAsync(q => q.Where(c => c.ContentType == contentType && c.Published));
        }
    }
}
