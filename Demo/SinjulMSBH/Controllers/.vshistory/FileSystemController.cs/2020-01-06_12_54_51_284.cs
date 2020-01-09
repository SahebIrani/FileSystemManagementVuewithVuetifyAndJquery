
using Microsoft.AspNetCore.Mvc;

namespace Demo.SinjulMSBH.Controllers
{
	public sealed class FileSystemController :
		Controller
	{
		private readonly IFileSystemService _fileSystemService;

		public FileSystemController(
			IFileSystemService fileSystemService)
		{
			_fileSystemService = fileSystemService;
		}

		public IActionResult Index(
			string fullName = null,
			string formatterName = null)
		{
			var data = _fileSystemService.GetAllFileSystemObject(
				fullName);

			var json = _fileSystemService.ToJson(
				data,
				FormatterFactory.CreateInstance(formatterName));

			return Json(
				json);
		}

		[ActionName("check-directory")]
		public IActionResult DirectoryExists(
			string fullName = null)
		{
			var exists = _fileSystemService.DirectoryExists(
				fullName);

			return Json(
				exists);
		}

	}
}
