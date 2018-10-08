using System;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Views;
using TestTagPart.OrchardCore.Models;

namespace TestTagPart.OrchardCore.Settings
{
    public class TestTagPartPartSettingsDisplayDriver : ContentPartDefinitionDisplayDriver
    {
        public override IDisplayResult Edit(ContentPartDefinition contentPartDefinition)
        {
            if (!String.Equals(nameof(TestTagPartPart), contentPartDefinition.Name, StringComparison.Ordinal))
            {
                return null;
            }

            return Initialize<TestTagPartPartSettingsViewModel>("TestTagPartPartSettings_Edit", model =>
            {
                var settings = contentPartDefinition.GetSettings<TestTagPartPartSettings>();

                model.MySetting = settings.MySetting;
                model.TestTagPartPartSettings = settings;

                return Task.CompletedTask;
            }).Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentPartDefinition contentPartDefinition, UpdatePartEditorContext context)
        {
            if (!String.Equals(nameof(TestTagPartPart), contentPartDefinition.Name, StringComparison.Ordinal))
            {
                return null;
            }

            var model = new TestTagPartPartSettingsViewModel();

            if (await context.Updater.TryUpdateModelAsync(model, Prefix, m => m.MySetting))
            {
                context.Builder.WithSettings(new TestTagPartPartSettings { MySetting = model.MySetting });
            }

            return Edit(contentPartDefinition, context.Updater);
        }
    }
}