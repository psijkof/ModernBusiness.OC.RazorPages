using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TestTagPart.OrchardCore.Settings
{
    public class TestTagPartPartSettingsViewModel
    {
        public string MySetting { get; set; }

        [BindNever]
        public TestTagPartPartSettings TestTagPartPartSettings { get; set; }
    }
}
