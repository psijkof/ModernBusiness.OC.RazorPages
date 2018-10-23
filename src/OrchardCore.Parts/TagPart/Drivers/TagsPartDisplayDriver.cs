using System.Linq;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using Tags.OrchardCore.Models;
using Tags.OrchardCore.Settings;
using Tags.OrchardCore.ViewModels;

namespace Tags.OrchardCore.Drivers
{
    public class TagsPartDisplayDriver : ContentPartDisplayDriver<TagsPart>
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public TagsPartDisplayDriver(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public override IDisplayResult Display(TagsPart TagsPart)
        {
            return Combine(
                Initialize<TagsPartViewModel>("TagsPart", m => BuildViewModel(m, TagsPart))
                    .Location("Detail", "Content:20"),
                Initialize<TagsPartViewModel>("TagsPart_Summary", m => BuildViewModel(m, TagsPart))
                    .Location("Summary", "Meta:5")
            );
        }
        
        public override IDisplayResult Edit(TagsPart TagsPart)
        {
            return Initialize<TagsPartViewModel>("TagsPart_Edit", m => BuildViewModel(m, TagsPart));
        }

        public override async Task<IDisplayResult> UpdateAsync(TagsPart model, IUpdateModel updater)
        {
            var settings = GetTagsPartSettings(model);

            await updater.TryUpdateModelAsync(model, Prefix, t => t.Show, t => t.Tags);
            
            return Edit(model);
        }

        public TagsPartSettings GetTagsPartSettings(TagsPart part)
        {
            var contentTypeDefinition = _contentDefinitionManager.GetTypeDefinition(part.ContentItem.ContentType);
            var contentTypePartDefinition = contentTypeDefinition.Parts.FirstOrDefault(p => p.PartDefinition.Name == nameof(TagsPart));
            var settings = contentTypePartDefinition.GetSettings<TagsPartSettings>();

            return settings;
        }

        private Task BuildViewModel(TagsPartViewModel model, TagsPart part)
        {
            var settings = GetTagsPartSettings(part);

			model.ContentItem = part.ContentItem;
            model.Show = part.Show;
			model.Tags = part.Tags;
            model.TagsPart = part;
            model.Settings = settings;

            return Task.CompletedTask;
        }
    }
}
