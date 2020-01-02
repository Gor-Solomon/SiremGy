using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SiremGy.DAL.Entities;
using System;

namespace SiremGy.DAL.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable, IAsyncDisposable
           where TEntity : class, IEntity
    {
        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void RemoveRange(IEnumerable<TEntity> entities);
        void RemoveAll();
        void Edit(TEntity entity);
        void Delete(int entity);
        void Attach(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(int id);
        Task<bool> SaveChangesAsync(bool acceptAllChanges = true);
    }
}
