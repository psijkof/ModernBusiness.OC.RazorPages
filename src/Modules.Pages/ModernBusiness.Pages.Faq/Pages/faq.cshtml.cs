using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchardCore;
using OrchardCore.ContentManagement;

namespace ModernBusiness.Pages.Faq
{
    public class FaqModel : PageModel
    {
        private readonly IOrchardHelper _orchard;

        public FaqModel(IOrchardHelper orchard)
        {
            _orchard = orchard;
        }

        public ContentItem Faq { get; private set; }
        public IEnumerable<ContentItem> FaqList { get; private set; }

        public async void OnGet()
        {
            Faq = (await _orchard.GetRecentContentItemsByContentTypeAsync("FAQ")).SingleOrDefault();
            FaqList = await _orchard.GetRecentContentItemsByContentTypeAsync("QuestionAnswer");
        }
    }
}