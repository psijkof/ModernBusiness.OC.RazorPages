using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.Indexing;
using TestTagPart.OrchardCore.Models;

namespace TestTagPart.OrchardCore.Indexing
{
	public class TestTagPartIndexHandler : ContentPartIndexHandler<TestTagPartPart>
	{
		public override Task BuildIndexAsync(TestTagPartPart part, BuildPartIndexContext context)
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
