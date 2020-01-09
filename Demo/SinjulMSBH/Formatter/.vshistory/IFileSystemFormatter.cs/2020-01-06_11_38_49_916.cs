using FSL.FileSystem.Core.Models;
using System.Collections.Generic;

namespace Demo.SinjulMSBH.Formatter
{
    public interface IFileSystemFormatter
    {
        object ToJson(
            IEnumerable<FileSystemObject> fileSystemObjects);
    }
}
