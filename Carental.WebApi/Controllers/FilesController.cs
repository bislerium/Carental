using Carental.Application.Features.File.Commands.UploadFile;
using Carental.Application.Features.File.Queries.DownloadFile;
using Carental.Application.Interfaces.File;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carental.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class FilesController : ControllerBase
    {
        private readonly IFileStore _fileStore;
        private readonly IMediator _mediator;

        public FilesController(IFileStore fileStore, IMediator mediator)
        {
            _fileStore = fileStore;
            _mediator = mediator;
        }

        [HttpPost("")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            UploadFileCommand command = new(file);
            Result<string> result = await _mediator.Send(command);
            return result.IsSuccess 
                ? CreatedAtAction(nameof(Download), new { fileName = result.Value }, null)
                : BadRequest(result.Reasons);            
        }

        [HttpGet("{fileName}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Download([FromRoute] string fileName)
        {
            DownloadFileQuery command = new(fileName);
            Result<(byte[] Content, string ContentType)> result = await _mediator.Send(command);
            
            return result.IsSuccess
                ? File(result.Value.Content, result.Value.ContentType)
                : BadRequest(result.Reasons);            
        }
    }
}
