using Carental.Application.Exceptions;
using Carental.Application.Interfaces.File;
using Microsoft.AspNetCore.Http;

namespace Carental.Infrastructure.Persistence.FileStore
{
    public class AppFileStore : IFileStore
    {
        private const string MEDIA_FOLDER = "D://Media";

        public AppFileStore()
        {
            if (!Directory.Exists(MEDIA_FOLDER))
            {
                Directory.CreateDirectory(MEDIA_FOLDER);
            }
        }

        public async Task<byte[]> Read(string path)
        {
            path = Path.Combine(MEDIA_FOLDER, path);

            if (!File.Exists(path))
            {
                throw new NotFoundException("File doesnot exist.");
            }

            byte[] fileBytes = await File.ReadAllBytesAsync(path);

            return fileBytes;
        }

        public async Task<string> Write(IFormFile file)
        {
            if (file is null || file.Length == 0)
            {
                throw new ArgumentException("File is required", nameof(file));
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName).ToLower();
            var filePath = Path.Combine(MEDIA_FOLDER, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }
    }
}
