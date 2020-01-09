using System.Collections.Generic;

using Demo.SinjulMSBH.Models;

namespace Demo.SinjulMSBH.Formatter
{
	public interface IFileSystemFormatter
	{
		object ToJson(IEnumerable<FileSystemObject> fileSystemObjects);
	}
}
