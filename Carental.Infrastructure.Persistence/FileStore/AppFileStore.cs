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

        public async Task<byte[]> Read(string path, CancellationToken cancellationToken = default)
        {
            if (!File.Exists(path))
            {
                throw new NotFoundException();
            }

            byte[] fileBytes = await File.ReadAllBytesAsync(path, cancellationToken);

            return fileBytes;
        }

        public async Task<Tuple<string, string, string>> Write(IFormFile file, CancellationToken cancellationToken = default)
        {
            var fileId = Guid.NewGuid().ToString();
            var fileName =  fileId + Path.GetExtension(file.FileName).ToLower();
            var filePath = Path.Combine(MEDIA_FOLDER, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream, cancellationToken);
            }

            return Tuple.Create(fileId, fileName, filePath);
        }
    }
}
