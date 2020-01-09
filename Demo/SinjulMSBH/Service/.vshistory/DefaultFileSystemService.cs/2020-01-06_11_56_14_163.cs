using System.Collections.Generic;
using System.Linq;

using Demo.SinjulMSBH.Formatter;
using Demo.SinjulMSBH.Models;
using Demo.SinjulMSBH.Repository;

namespace Demo.SinjulMSBH.Service
{
	public sealed class DefaultFileSystemService : IFileSystemService
	{
		public DefaultFileSystemService(IFileSystemRepository fileSystemRepository) =>
			FileSystemRepository = fileSystemRepository;

		public IFileSystemRepository FileSystemRepository { get; }

		public IEnumerable<FileSystemObject> GetAllFileSystemObject(string fullName)
		{
			IReadOnlyList<FileSystemObject> objs = FileSystemRepository.SelectMany(fullName).ToList();

			if (objs.Count > 0)
				objs.OrderBy(obj => obj.IsFile.ToString());

			return objs;
		}

		public object ToJson(IEnumerable<FileSystemObject> objs,
					   IFileSystemFormatter fileSystemFormatter = null)
		{
			fileSystemFormatter = fileSystemFormatter ?? FormatterFactory.CreateInstance();

			return fileSystemFormatter.ToJson(
				objs);
		}

		public bool DirectoryExists(
			string fullName)
		{
			var result = FileSystemRepository.Exists(
				fullName);

			return result;
		}
	}
}
