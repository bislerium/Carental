using Carental.Domain.Repositories.Base;
namespace Carental.Domain.Repositories
{
    public interface IFileRepository: IRepository<Entities.File>
    {

        //Throws error if the file's fullname doesn't match.
        Task<Entities.File> FindByFullNameAsync(string fullName, CancellationToken cancellationToken = default);
    }
}
