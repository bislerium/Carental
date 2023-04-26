using Carental.Domain.Repositories;
using Carental.Infrastructure.Persistence.Repositories.Base;

namespace Carental.Infrastructure.Persistence.Repositories
{
    public class FileRepository : Repostiory<Domain.Entities.File>, IFileRepository
    {
        public FileRepository(AppDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<Domain.Entities.File> FindByFullNameAsync(string fullName, CancellationToken cancellationToken = default)
        {          
            string fileId = Path.GetFileNameWithoutExtension(fullName);
            string fileExtension = Path.GetExtension(fullName);

            Domain.Entities.File? file = await FindByIdAsync(fileId, cancellationToken);
            if (file is null || string.Compare(file.Extension, fileExtension, true) != 0)
            {
                throw new FileNotFoundException();
            }
            return file;
        }
    }
}
