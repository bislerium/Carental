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
            string fileExtension = Path.GetExtension(fullName).ToLower();

            Domain.Entities.File? file = await FindByIdAsync(fileId, cancellationToken);
            if (file == null || !file.Extension.Equals(fileExtension))
            {
                throw new FileNotFoundException();
            }
            return file;
        }
    }
}
