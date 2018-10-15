using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchardCore;
using OrchardCore.ContentManagement;

namespace ModernBusiness.Pages.PricePlan
{
    public class Price_PlanModel : PageModel
    {
        private readonly IOrchardHelper _orchard;

        public Price_PlanModel(IOrchardHelper orchard)
        {
            _orchard = orchard;
        }

        public ContentItem Pricing { get; private set; }
        public IEnumerable<ContentItem> PriceList { get; private set; }

        public async void OnGet()
        {
            Pricing = (await _orchard.GetRecentContentItemsByContentTypeAsync("Pricing")).SingleOrDefault();
            PriceList = await _orchard.GetRecentContentItemsByContentTypeAsync("PricePlan");
        }
    }
}