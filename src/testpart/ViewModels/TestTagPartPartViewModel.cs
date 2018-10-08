using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;
using TestTagPart.OrchardCore.Models;
using TestTagPart.OrchardCore.Settings;

namespace TestTagPart.OrchardCore.ViewModels
{
    public class TestTagPartPartViewModel
    {
        public string MySetting { get; set; }

		public string Tags { get; set; }

        public bool Show { get; set; }

        [BindNever]
        public ContentItem ContentItem { get; set; }

        [BindNever]
        public TestTagPartPart TestTagPartPart { get; set; }

        [BindNever]
        public TestTagPartPartSettings Settings { get; set; }
    }
}
