using Azure.Core;
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
    public class FileController : ControllerBase
    {
        private readonly IFileStore _fileStore;
        private readonly IMediator _mediator;

        public FileController(IFileStore fileStore, IMediator mediator)
        {
            this._fileStore = fileStore;
            this._mediator = mediator;
        }

        [HttpPost]
        [Route("[action]")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            UploadFileCommand command = new(file);
            Result<string> result = await _mediator.Send(command);
            return result.IsSuccess 
                ? CreatedAtAction(nameof(Download), new { fileName = result.Value }, null)
                : BadRequest(result.Reasons);            
        }

        [HttpGet]
        [Route("{fileName}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Download([FromRoute] string fileName)
        {
            DownloadFileQuery command = new(fileName);
            Result<Tuple<byte[], string>> result = await _mediator.Send(command);

            return result.IsSuccess
                ? File(result.Value.Item1, result.Value.Item2)
                : BadRequest(result.Reasons);            
        }
    }
}
