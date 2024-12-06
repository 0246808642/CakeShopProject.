using CakeShopProject.Domain.Interface.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CakeShopProject.Data.Repository.Base;

public abstract class BaseRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    private readonly DbContext _context; // Context do EF
    private DbSet<TEntity> _dbSet; // Conjunto de Entidades

    protected BaseRepository(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<TEntity>();  
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        if(entity == null) throw new ArgumentNullException(nameof(entity));
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task AddRangeAsync(IList<TEntity> entity)
    {
        if (entity == null || !entity.Any()) throw new ArgumentNullException(nameof(entity));
        await _dbSet.AddRangeAsync(entity);
        await _context.SaveChangesAsync();

    }

    public async Task DeleteAsync(TEntity entity)
    {
        if(entity == null) throw new ArgumentException(nameof(entity));
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity> DeletedAsync(long id)
    {
        var searchId = await GetByIdAsync(id);
        if(searchId == null) throw new ArgumentNullException(nameof(searchId));

        _dbSet.Remove(searchId);
        await _context.SaveChangesAsync();
        return searchId;

    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
    {
      if(predicate == null) throw new ArgumentNullException(nameof(predicate));
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
    }
    public async Task<TEntity> GetByIdAsync(long id)
    {
        return await _dbSet.FindAsync(id);
    }

    
    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        if (entities == null || !entities.Any()) throw new ArgumentNullException(nameof(entities));

        foreach (var entity in entities)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        await _context.SaveChangesAsync();
    }
}

