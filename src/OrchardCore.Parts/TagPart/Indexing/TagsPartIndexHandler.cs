using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.Indexing;
using Tags.OrchardCore.Models;

namespace Tags.OrchardCore.Indexing
{
	public class TagsIndexHandler : ContentPartIndexHandler<TagsPart>
	{
		public override Task BuildIndexAsync(TagsPart part, BuildPartIndexContext context)
		{
			var options = DocumentIndexOptions.Store;

			foreach (var key in context.Keys)
			{
				context.DocumentIndex.Set(key, part.Tags, options);
			}

			return Task.CompletedTask;
		}
	}
}
