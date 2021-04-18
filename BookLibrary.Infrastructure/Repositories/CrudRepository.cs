using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookLibrary.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Infrastructure.Repositories
{
    public class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : class
    {
        protected readonly BooksContext Context;
        protected internal readonly DbSet<TEntity> DbSet;

        public CrudRepository(BooksContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }
        
        public async Task<IReadOnlyList<TEntity>> AddAsync(params TEntity[] entities)
        {
            await DbSet.AddRangeAsync(entities);
            return entities;
        }
        
        public async Task<IReadOnlyList<TEntity>> GetAllAsync(bool isTracking = true)
        {
            var query = DbSet.AsQueryable();
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();
        }

        public TEntity Update(TEntity entity)
        {
            DbSet.Update(entity);
            return entity;
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }
        
        public void RemoveRange(IReadOnlyList<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression, bool isTracking = true)
        {
            var query = DbSet.AsQueryable();
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.SingleOrDefaultAsync(expression);
        }
        
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, bool isTracking = true)
        {
            var query = DbSet.AsQueryable();
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(expression);
        }
        
        public async Task<IReadOnlyList<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> expression, bool isTracking = true)
        {
            var query = DbSet.AsQueryable();
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.Where(expression).ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            var query = DbSet.AsQueryable();
            return await query.AnyAsync(expression);
        }
    }

}