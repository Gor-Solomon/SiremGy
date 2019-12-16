using Microsoft.EntityFrameworkCore;
using SiremGy.DAL.Entities;
using SiremGy.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiremGy.DAL.DataAccess
{
    public abstract class BaseRepository<TEntity, TDbContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
        where TDbContext : DbContext
    {
        protected readonly TDbContext _dbContext;
        private bool _disposed = false;

        public BaseRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException(nameof(entity));

            var result = await _dbContext.Set<TEntity>().AddAsync(entity);

            return result.Entity;
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null || entities.Any(e => e == null))
                throw new ArgumentException(nameof(entities));

            _dbContext.Set<TEntity>().AddRange(entities);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null || entities.Any(x => x == null))
                throw new ArgumentException(nameof(entities));

            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public virtual void Edit(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException(nameof(entity));
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        protected virtual void DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public virtual async void Delete(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            if (entity != null)
                DeleteAsync(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>()
                .ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbContext.Set<TEntity>()
                .Where(filter)
                .ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<int> CountAsync()
        {
            return await _dbContext.Set<TEntity>().CountAsync();
        }

        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).CountAsync();
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
                return await _dbContext.Set<TEntity>().AnyAsync(predicate);
            return await _dbContext.Set<TEntity>().AnyAsync();
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
                return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync();
        }

        public virtual void Attach(TEntity entity)
        {
            _dbContext.Set<TEntity>().Attach(entity);
        }

        public virtual void RemoveAll()
        {
            var items = _dbContext.Set<TEntity>();
            _dbContext.Set<TEntity>().RemoveRange(items);
        }

        public virtual Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().AllAsync(predicate);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _dbContext?.Dispose();
                _disposed = true;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (!_disposed && _dbContext != null)
            {
                await _dbContext.DisposeAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
           await _dbContext.SaveChangesAsync();
        }

        ~BaseRepository()
        {
            Dispose(false);
        }
    }
}
