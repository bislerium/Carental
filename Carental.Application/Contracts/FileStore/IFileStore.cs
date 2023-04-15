using Microsoft.AspNetCore.Http;

namespace Carental.Application.Interfaces.File
{
    public interface IFileStore
    {
        Task<byte[]> Read(string path);

        Task<string> Write(IFormFile file);
    }
}
