namespace Demo.SinjulMSBH.Repository
{
    public interface IFileSystemRepository :
        ISelectRepository<Models.FileSystemObject>,
        IDeleteRepository<Models.FileSystemObject>
    {
        bool Exists(
            string fullName);
    }
}
