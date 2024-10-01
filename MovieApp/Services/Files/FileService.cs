namespace MovieApp.Services.Files
{

    public class FileService : IFileService
    {
        public async Task<byte[]> GetFile(string path)
        {
            using var fileStream = new FileStream(path, FileMode.Open);
            var buffer = new byte[fileStream.Length];
            await fileStream.ReadAsync(buffer, 0, (int)fileStream.Length);

            return buffer;
        }

        public async Task SaveFile(string directoryPath, string fileName, Stream file)
        {
            Directory.CreateDirectory(directoryPath);
            string fullPath = $"{directoryPath}/{fileName}";
            using var fileStream = new FileStream(fullPath, FileMode.OpenOrCreate);

            await file.CopyToAsync(fileStream);
        }
    }
}
