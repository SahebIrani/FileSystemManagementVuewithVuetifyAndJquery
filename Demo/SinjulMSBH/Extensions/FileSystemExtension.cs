using System.Collections.Generic;

using Demo.SinjulMSBH.Models;

namespace Demo.SinjulMSBH.Extensions
{
	public static class FileSystemExtension
	{
		public static void AddIfNotNull(
			this IList<FileSystemObject> objs,
			FileSystemObject obj)
		{
			if (objs == null || obj == null) return;

			objs.Add(obj);
		}
	}
}
