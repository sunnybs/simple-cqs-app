using System.Threading;
using System.Threading.Tasks;

namespace BookLibrary.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        Task SaveChangesAsync(CancellationToken cancellationToken);
        ICrudRepository<TEntity> Get<TEntity>() where TEntity : class;
    }
}