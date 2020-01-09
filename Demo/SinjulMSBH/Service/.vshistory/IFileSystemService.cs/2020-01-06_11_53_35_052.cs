using System.Collections.Generic;

using Demo.SinjulMSBH.Models;

namespace Demo.SinjulMSBH.Service
{
	public interface IFileSystemService
	{
		IEnumerable<FileSystemObject> GetAllFileSystemObject(string fullName);

		object ToJson(IEnumerable<FileSystemObject> objs, IFileSystemFormatter fileSystemFormatter = null);

		bool DirectoryExists(string fullName);
	}
}
