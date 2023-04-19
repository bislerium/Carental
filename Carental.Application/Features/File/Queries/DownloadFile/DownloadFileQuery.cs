using Carental.Application.Abstractions.CQRS.Command;

namespace Carental.Application.Features.File.Queries.DownloadFile
{
    public record DownloadFileQuery(String FileName): ICommand<Tuple<byte[], string>>;
}
