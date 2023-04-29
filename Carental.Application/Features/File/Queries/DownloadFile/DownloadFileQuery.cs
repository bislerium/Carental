using Carental.Application.Abstractions.CQRS.Command;

namespace Carental.Application.Features.File.Queries.DownloadFile
{
    public record DownloadFileQuery(string FileName): ICommand<(byte[] Content, string ContentType)>;
}
