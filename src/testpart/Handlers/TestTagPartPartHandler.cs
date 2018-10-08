using OrchardCore.ContentManagement.Handlers;
using System.Threading.Tasks;
using TestTagPart.OrchardCore.Models;

namespace TestTagPart.OrchardCore.Handlers
{
    public class TestTagPartPartHandler : ContentPartHandler<TestTagPartPart>
    {
        public override Task InitializingAsync(InitializingContentContext context, TestTagPartPart part)
        {
            part.Show = true;

            return Task.CompletedTask;
        }
    }
}