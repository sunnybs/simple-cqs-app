using System.Threading;
using System.Threading.Tasks;
using BookLibrary.Application.Common.Interfaces;

namespace BookLibrary.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BooksContext _context;

        public UnitOfWork(BooksContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public ICrudRepository<TEntity> Get<TEntity>() where TEntity : class
        {
            return new CrudRepository<TEntity>(_context);
        }

    }
}