using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Tags.OrchardCore.Settings
{
    public class TagsPartSettingsViewModel
    {
		public bool Required { get; set; }
		public bool Multiple { get; set; }

		[BindNever]
        public TagsPartSettings TagsPartSettings { get; set; }
    }
}
