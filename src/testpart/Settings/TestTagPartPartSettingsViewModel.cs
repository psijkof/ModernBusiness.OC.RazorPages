using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TestTagPart.OrchardCore.Settings
{
    public class TestTagPartPartSettingsViewModel
    {
        public string MySetting { get; set; }
		public bool Required { get; set; }
		public bool Multiple { get; set; }

		[BindNever]
        public TestTagPartPartSettings TestTagPartPartSettings { get; set; }
    }
}
