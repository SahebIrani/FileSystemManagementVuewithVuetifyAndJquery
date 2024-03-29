﻿using System.Collections.Generic;
using System.Linq;

using Demo.SinjulMSBH.Models;

namespace Demo.SinjulMSBH.Formatter
{
	public sealed class DefaultFileSystemFormatter : IFileSystemFormatter
	{
		public object ToJson(IEnumerable<FileSystemObject> objs)
		{
			var dateTimeFormat = "MM/dd/yyyy HH:mm";

			return objs?.Select(obj => new
			{
				obj.Name,
				Id = obj.Id.Replace(@"\", @"\\"),
				obj.IsFile,
				obj.HasChilds,
				LastWriteTime = obj.LastWriteTime?.ToString(dateTimeFormat),
				CreationTime = obj.CreationTime?.ToString(dateTimeFormat),
				obj.Size,
				obj.Extension
			});
		}
	}
}
