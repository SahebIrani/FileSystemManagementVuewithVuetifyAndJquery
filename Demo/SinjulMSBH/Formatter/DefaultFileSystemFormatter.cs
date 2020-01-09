using System.Collections.Generic;
using System.Linq;

using Demo.SinjulMSBH.Models;

namespace Demo.SinjulMSBH.Formatter
{
	public sealed class DefaultFileSystemFormatter : IFileSystemFormatter
	{
		public object ToJson(IEnumerable<FileSystemObject> objs)
		{
			const string dateTimeFormat = "MM/dd/yyyy HH:mm";

			return objs?.Select(obj => new
			{
				Id = obj.Id.Replace(@"\", @"\\"),
				obj.Name,
				obj.IsFile,
				obj.HasChilds,
				obj.Size,
				obj.Extension,
				CreationTime = obj.CreationTime?.ToString(dateTimeFormat),
				LastWriteTime = obj.LastWriteTime?.ToString(dateTimeFormat),
			});
		}
	}
}
