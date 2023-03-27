using Application.Interfaces.File;

namespace Infrastructure.Persistence.FileProviders
{
    internal class FileProvider : IFileProvider
    {
        private readonly string _rootpath;

        private const string _MEDIA_FOLDER = "Media";

        public Stream Read(string path)
        {
            using FileStream stream = new(path, FileMode.Open);
            return stream;
        }

        public string Write(Stream file, string fileName)
        {
            string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
            string filePath = Path.Combine(_rootpath, _MEDIA_FOLDER, newFileName);

            using FileStream stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);
            return filePath;
        }
    }
}
