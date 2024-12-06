using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CakeShopProject.Domain.Interface.Service.Base
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IList<TEntity> entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(IEnumerable<TEntity> entity);
        Task<TEntity> DeletedAsync(long id);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(long id);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

    }
}
