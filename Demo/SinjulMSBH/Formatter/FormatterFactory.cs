using System;

namespace Demo.SinjulMSBH.Formatter
{
	public static class FormatterFactory
	{
		public static IFileSystemFormatter CreateInstance(string formatterName = null)
		{
			formatterName ??= "Default";

			Type type = Type.GetType($"Demo.SinjulMSBH.Formatter.{formatterName}FileSystemFormatter");

			return Activator.CreateInstance(type) as IFileSystemFormatter;
		}
	}
}
