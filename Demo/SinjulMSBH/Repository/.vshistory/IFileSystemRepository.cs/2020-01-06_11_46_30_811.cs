using Demo.SinjulMSBH.Models;

namespace Demo.SinjulMSBH.Repository
{
	public interface IFileSystemRepository : ISelectRepository<FileSystemObject>, IDeleteRepository<FileSystemObject>
	{
		bool Exists(
			string fullName);
	}
}
