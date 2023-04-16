using Azure.Core;
using Carental.Application.Features.File.Commands.UploadFile;
using Carental.Application.Features.File.Queries.DownloadFile;
using Carental.Application.Interfaces.File;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Carental.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileStore fileStore;
        private IMediator mediator;

        public FileController(IFileStore fileStore, IMediator mediator)
        {
            this.fileStore = fileStore;
            this.mediator = mediator;
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            UploadFileCommand command = new(file);
            Result<string> result = await mediator.Send(command);
            if (result.IsSuccess) 
            {
                string resourceURL = Url.Action(nameof(Download), new { fileName = result.Value })!;
                Response.Headers.Location = resourceURL;
                return NoContent();
            } else
            {
                return BadRequest(result.Reasons);
            }
        }

        [Route("{fileName}")]
        [HttpGet]
        public async Task<IActionResult> Download([FromRoute] string fileName)
        {
            DownloadFileCommand command = new(fileName);
            Result<Tuple<byte[], string>> result = await mediator.Send(command);

            return result.IsSuccess
                ? File(result.Value.Item1, result.Value.Item2)
                : BadRequest(result.Reasons);            
        }
    }
}
