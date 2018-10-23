using System;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Views;
using Tags.OrchardCore.Models;

namespace Tags.OrchardCore.Settings
{
    public class TagsPartSettingsDisplayDriver : ContentPartDefinitionDisplayDriver
    {
        public override IDisplayResult Edit(ContentPartDefinition contentPartDefinition)
        {
            if (!String.Equals(nameof(TagsPart), contentPartDefinition.Name, StringComparison.Ordinal))
            {
                return null;
            }

            return Initialize<TagsPartSettingsViewModel>("TagsPartSettings_Edit", model =>
            {
                var settings = contentPartDefinition.GetSettings<TagsPartSettings>();

				model.Required = settings.Required;
				model.Multiple = settings.Multiple;
                model.TagsPartSettings = settings;

                return Task.CompletedTask;
            }).Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentPartDefinition contentPartDefinition, UpdatePartEditorContext context)
        {
            if (!String.Equals(nameof(TagsPart), contentPartDefinition.Name, StringComparison.Ordinal))
            {
                return null;
            }

            var model = new TagsPartSettingsViewModel();

            if (await context.Updater.TryUpdateModelAsync(model, Prefix, m => m.Multiple, m => m.Required ))
            {
                context.Builder.WithSettings(new TagsPartSettings
				{
					Required = model.Required,
					Multiple = model.Multiple
				});
            }

            return Edit(contentPartDefinition, context.Updater);
        }
    }
}