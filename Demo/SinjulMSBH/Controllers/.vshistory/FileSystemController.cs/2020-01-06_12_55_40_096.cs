
using Demo.SinjulMSBH.Service;

using Microsoft.AspNetCore.Mvc;

namespace Demo.SinjulMSBH.Controllers
{
	public sealed class FileSystemController :
		Controller
	{
		public FileSystemController(IFileSystemService fileSystemService)
			=> FileSystemService = fileSystemService ?? throw new System.ArgumentNullException(nameof(fileSystemService));
		public IFileSystemService FileSystemService { get; }

		public IActionResult Index(
			string fullName = null,
			string formatterName = null)
		{
			var data = FileSystemService.GetAllFileSystemObject(
				fullName);

			var json = FileSystemService.ToJson(
				data,
				FormatterFactory.CreateInstance(formatterName));

			return Json(
				json);
		}

		[ActionName("check-directory")]
		public IActionResult DirectoryExists(string fullName = null)
		{
			bool exists = FileSystemService.DirectoryExists(fullName);
			return Json(exists);
		}

	}
}
