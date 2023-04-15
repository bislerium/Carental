using Carental.Application.Interfaces.File;
using Microsoft.AspNetCore.Mvc;

namespace Carental.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileStore fileStore;

        public FileController(IFileStore fileStore)
        {
            this.fileStore = fileStore;
        }

        //[Route("{fileName}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] string fileName)
        {
            byte[] file = await fileStore.Read(fileName);

            string extension = Path.GetExtension(fileName);
            string contentType = extension.ToLower() switch
            {
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".svg" => "image/svg+xml",
                ".pdf" => "application/pdf",
                _ => "application/octet-stream",
            };

            return File(file, contentType);
            
        }
    }
}
