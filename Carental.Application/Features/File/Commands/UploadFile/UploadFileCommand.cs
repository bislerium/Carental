using Carental.Application.Abstractions.CQRS.Command;
using Microsoft.AspNetCore.Http;

namespace Carental.Application.Features.File.Commands.UploadFile
{
    public record UploadFileCommand(IFormFile File): ICommand<string>;
}