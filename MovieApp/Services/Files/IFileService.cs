namespace MovieApp.Services.Files
{
    public interface IFileService
    {
        Task SaveFile(string directoryPath, string fileName, Stream file);
        Task<byte[]> GetFile(string path);
    }
}
