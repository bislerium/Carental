using Carental.Application.Abstractions.CQRS.Command;
using Carental.Application.Interfaces.File;
using Carental.Domain.UnitOfWork;
using FluentResults;

namespace Carental.Application.Features.File.Commands.UploadFile
{
    internal class UploadFileCommandHandler : ICommandHandler<UploadFileCommand, string>
    {
        public readonly IFileStore fileStore;
        public IUnitOfWork unitOfWork;

        public UploadFileCommandHandler(IFileStore fileStore, IUnitOfWork unitOfWork)
        {
            this.fileStore = fileStore;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                (string fileId, string fileName, string filePath) = await fileStore.Write(request.File, cancellationToken);

                Domain.Entities.File file = new()
                {
                    Id = fileId,
                    FilePath = filePath,
                    ByteSize = request.File.Length,
                };

                unitOfWork.FileRepository.Add(file);
                await unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Ok(fileName);
            }
            catch
            {
                return Result.Fail(new Error("Something went wrong."));
            }

        }
    }
}
