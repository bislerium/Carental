using Carental.Application.Abstractions.CQRS.Command;
using Carental.Application.Interfaces.File;
using Carental.Domain.UnitOfWork;
using FluentResults;
using MimeTypes;

namespace Carental.Application.Features.File.Queries.DownloadFile
{
    public class DownloadFileQueryHandler : ICommandHandler<DownloadFileQuery, Tuple<byte[], string>>
    {
        private readonly IFileStore fileStore;
        private readonly IUnitOfWork unitOfWork;

        public DownloadFileQueryHandler(IFileStore fileStore, IUnitOfWork unitOfWork)
        {
            this.fileStore = fileStore;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<Tuple<byte[], string>>> Handle(DownloadFileQuery request, CancellationToken cancellationToken)
        {
            string errorMessage;
            try
            {
                Domain.Entities.File file = await unitOfWork.FileRepository.FindByFullNameAsync(request.FileName, cancellationToken);

                byte[] fileBytes = await fileStore.Read(file.FilePath, cancellationToken);
                string mimeType = MimeTypeMap.GetMimeType(file.Extension);

                return Tuple.Create(fileBytes, mimeType);
            }
            catch (FileNotFoundException)
            {
                errorMessage = $"{request.FileName} not found.";
            }
            catch (Exception)
            {
                errorMessage = "Something went wrong.";
            }
            return Result.Fail(new Error(errorMessage));
        }
    }
}
