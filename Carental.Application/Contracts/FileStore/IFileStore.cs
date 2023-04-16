using Microsoft.AspNetCore.Http;

namespace Carental.Application.Interfaces.File
{
    public interface IFileStore
    {
        Task<byte[]> Read(string path, CancellationToken cancellationToken = default);

        Task<Tuple<string, string, string>> Write(IFormFile file, CancellationToken cancellationToken = default);
    }
}
