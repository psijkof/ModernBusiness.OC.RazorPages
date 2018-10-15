using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernBusiness.Pages.Shared.ViewModels
{
    public class BreadCrumbViewModel
    {
        public string DisplayText { get; set; }
        public string SubTitle { get; set; }
        public ContentItem Content { get; set; } = null;
    }
}
