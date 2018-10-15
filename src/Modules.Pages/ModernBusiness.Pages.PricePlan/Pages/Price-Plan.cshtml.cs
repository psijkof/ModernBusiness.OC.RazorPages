using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using ModernBusiness.Pages.Shared.ViewModels;
using OrchardCore;
using OrchardCore.ContentManagement;

namespace ModernBusiness.Pages.PricePlan
{
    public class Price_PlanModel : PageModel
    {
        private readonly IOrchardHelper _orchard;
        private readonly IStringLocalizer T;

        public Price_PlanModel(IOrchardHelper orchard, IStringLocalizer<Price_PlanModel> t)
        {
            _orchard = orchard;
            T = t;
        }

        public ContentItem Pricing { get; private set; }
        public BreadCrumbViewModel BreadCrumbVM { get; private set; }
        public IEnumerable<ContentItem> PriceList { get; private set; }

        public async void OnGet()
        {
            Pricing = (await _orchard.GetRecentContentItemsByContentTypeAsync("Pricing")).SingleOrDefault();
            BreadCrumbVM = new BreadCrumbViewModel()
            {
                DisplayText = T[Pricing.DisplayText],
                SubTitle = T[(string)Pricing.Content.SubtitlePart?.Subtitle.Text ?? ""]
            };
            PriceList = (await _orchard.GetRecentContentItemsByContentTypeAsync("PricePlan")).OrderBy(p => p.Content.PricePlan.Price.Value);
        }
    }
}