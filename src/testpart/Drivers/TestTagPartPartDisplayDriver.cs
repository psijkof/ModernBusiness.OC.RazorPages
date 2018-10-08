using System.Linq;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using TestTagPart.OrchardCore.Models;
using TestTagPart.OrchardCore.Settings;
using TestTagPart.OrchardCore.ViewModels;

namespace TestTagPart.OrchardCore.Drivers
{
    public class TestTagPartPartDisplayDriver : ContentPartDisplayDriver<TestTagPartPart>
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public TestTagPartPartDisplayDriver(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public override IDisplayResult Display(TestTagPartPart TestTagPartPart)
        {
            return Combine(
                Initialize<TestTagPartPartViewModel>("TestTagPartPart", m => BuildViewModel(m, TestTagPartPart))
                    .Location("Detail", "Content:20"),
                Initialize<TestTagPartPartViewModel>("TestTagPartPart_Summary", m => BuildViewModel(m, TestTagPartPart))
                    .Location("Summary", "Meta:5")
            );
        }
        
        public override IDisplayResult Edit(TestTagPartPart TestTagPartPart)
        {
            return Initialize<TestTagPartPartViewModel>("TestTagPartPart_Edit", m => BuildViewModel(m, TestTagPartPart));
        }

        public override async Task<IDisplayResult> UpdateAsync(TestTagPartPart model, IUpdateModel updater)
        {
            var settings = GetTestTagPartPartSettings(model);

            await updater.TryUpdateModelAsync(model, Prefix, t => t.Show, t => t.Tags);
            
            return Edit(model);
        }

        public TestTagPartPartSettings GetTestTagPartPartSettings(TestTagPartPart part)
        {
            var contentTypeDefinition = _contentDefinitionManager.GetTypeDefinition(part.ContentItem.ContentType);
            var contentTypePartDefinition = contentTypeDefinition.Parts.FirstOrDefault(p => p.PartDefinition.Name == nameof(TestTagPartPart));
            var settings = contentTypePartDefinition.GetSettings<TestTagPartPartSettings>();

            return settings;
        }

        private Task BuildViewModel(TestTagPartPartViewModel model, TestTagPartPart part)
        {
            var settings = GetTestTagPartPartSettings(part);

            model.ContentItem = part.ContentItem;
            model.MySetting = settings.MySetting;
            model.Show = part.Show;
			model.Tags = part.Tags;
            model.TestTagPartPart = part;
            model.Settings = settings;

            return Task.CompletedTask;
        }
    }
}
