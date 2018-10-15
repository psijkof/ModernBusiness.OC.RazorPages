using OrchardCore.ContentManagement;

namespace Tags.OrchardCore.Models
{
    public class TagsPart : ContentPart
    {
        public bool Show { get; set; }

		public string Tags { get; set; }
    }
}
