using System.Collections.Generic;
using System.Linq;

using Demo.SinjulMSBH.Models;

using Humanizer;

namespace Demo.SinjulMSBH.Formatter
{
	public sealed class HumanizerFileSystemFormatter : IFileSystemFormatter
	{
		public object ToJson(IEnumerable<FileSystemObject> objs) =>
			objs?.Select(obj => new
			{
				obj.Name,
				Id = obj.Id.Replace(@"\", @"\\"),
				obj.IsFile,
				obj.HasChilds,
				LastWriteTime = obj.LastWriteTime.Humanize(),
				CreationTime = obj.CreationTime.Humanize(),
				Size = obj.Size.HasValue ?
				obj.Size.Value.Bytes().Humanize() :
				null,
				obj.Extension
			});
	}
}
