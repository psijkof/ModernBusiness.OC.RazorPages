using OrchardCore.ContentManagement.Handlers;
using System.Threading.Tasks;
using Tags.OrchardCore.Models;

namespace Tags.OrchardCore.Handlers
{
    public class TagsPartHandler : ContentPartHandler<TagsPart>
    {
        public override Task InitializingAsync(InitializingContentContext context, TagsPart part)
        {
			part.Show = true;
			part.Tags = "Hello there";

            return Task.CompletedTask;
        }
    }
}