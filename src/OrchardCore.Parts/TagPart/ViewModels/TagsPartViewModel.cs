using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;
using Tags.OrchardCore.Models;
using Tags.OrchardCore.Settings;

namespace Tags.OrchardCore.ViewModels
{
    public class TagsPartViewModel
    {
        public string MySetting { get; set; }

		public string Tags { get; set; }

        public bool Show { get; set; }

        [BindNever]
        public ContentItem ContentItem { get; set; }

        [BindNever]
        public TagsPart TagsPart { get; set; }

        [BindNever]
        public TagsPartSettings Settings { get; set; }
    }
}
