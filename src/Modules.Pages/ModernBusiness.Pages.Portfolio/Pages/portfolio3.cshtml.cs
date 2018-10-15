using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModernBusiness.Pages.Shared.Services;
using ModernBusiness.Pages.Shared.ViewModels;
using OrchardCore;
using OrchardCore.ContentManagement;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.Navigation;

namespace ModernBusiness.Pages.Pages
{
    public class portfolio3Model : PageModel
    {
        private readonly IOrchardHelper _orchard;
        public PagerInfo PagerInfo;
        public ContentItem Portfolio;
        private readonly DataRetriever _dataRetriever;

        public portfolio3Model(IOrchardHelper orchard, DataRetriever dataRetriever)
        {
            _orchard = orchard;
            _dataRetriever = dataRetriever;
        }

        public async void OnGet(int? pageIndex)
        {
            Portfolio = await _dataRetriever.InitializeContainer("Portfolio");

            PagerInfo = await _dataRetriever.InitializePager(6, "/portfolio3", "project");

            PagerInfo.CurrentPage = pageIndex ?? 1;

            PagerInfo.CurrentItemsOnPage = await _dataRetriever.GetCurrentPage();

        }

    }
}