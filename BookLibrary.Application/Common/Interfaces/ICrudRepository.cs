using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookLibrary.Application.Common.Interfaces
{
    public interface ICrudRepository <TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<IReadOnlyList<TEntity>> AddAsync(params TEntity[] entities);
        Task<IReadOnlyList<TEntity>> GetAllAsync(bool isTracking = true);
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IReadOnlyList<TEntity> entities);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression, bool isTracking = true);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, bool isTracking = true);
        Task<IReadOnlyList<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> expression, bool isTracking = true);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);

    }
}