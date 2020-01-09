
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Demo.SinjulMSBH.Formatter;
using Demo.SinjulMSBH.Service;

using Microsoft.AspNetCore.Mvc;

namespace Demo.SinjulMSBH.Controllers
{
	public sealed class FileSystemController : Controller
	{
		public FileSystemController(IFileSystemService fileSystemService)
			=> FileSystemService = fileSystemService ??
			throw new ArgumentNullException(nameof(fileSystemService));
		public IFileSystemService FileSystemService { get; }

		[HttpGet("GetAllFileSystem")]
		public JsonResult Index(
				string fullName = null,
				string formatterName = null)
		{
			IEnumerable<Models.FileSystemObject> data =
				FileSystemService.GetAllFileSystemObject(fullName);

			object result = FileSystemService.ToJson(
				data, FormatterFactory.CreateInstance(formatterName)
			);

			return Json(result);
		}

		[HttpGet("[Action]/{fileName}/{filePath}")]
		public async Task<FileResult> OpenFileAsync(string fileName, string filePath)
		{
			string path = $"{filePath}{fileName}";

			byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(path);

			return File(fileBytes, "application/force-download", fileName);
		}

		[ActionName("check-directory")]
		public JsonResult DirectoryExists(string fullName = null)
		{
			bool exists = FileSystemService.DirectoryExists(fullName);
			return Json(exists);
		}
	}
}
