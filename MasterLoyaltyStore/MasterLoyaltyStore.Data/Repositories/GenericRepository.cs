using System.Linq.Expressions;
using MasterLoyaltyStore.Data.Context;
using MasterLoyaltyStore.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MasterLoyaltyStore.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    
    protected readonly StoreDbContext _context;
    protected readonly DbSet<T> _dbSet;
    
    //Constructor
    public GenericRepository(StoreDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<T>();
    }
    
    
    #region Queries
    public virtual async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
    }

    public virtual async Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
       return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync(cancellationToken);
    }

    public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {

        return await _dbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(predicate,cancellationToken);
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(predicate, cancellationToken);
    }

    public virtual async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        if( predicate == null)
            return await _dbSet.CountAsync(cancellationToken);

        return await _dbSet.CountAsync(predicate, cancellationToken);
    }
    #endregion
    
    
    #region Pagionation
    public virtual async Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> predicate, Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _dbSet.AsNoTracking();
        
        if( filter != null)
            query = query.Where(filter);
        
        var totalCount = await query.CountAsync();

        if (orderBy != null)
            query = orderBy(query);

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
        
        return (items, totalCount);

    }

    #endregion
    
    #region Commands
    public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        if( entity == null )
            throw new ArgumentNullException(nameof(entity));
        
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public virtual async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        if( entities == null || !entities.Any())
            throw new ArgumentNullException(nameof(entities));
        
        await _dbSet.AddRangeAsync(entities, cancellationToken);
    }

    public void Update(T entity)
    {
        if( entity == null)
            throw new ArgumentNullException(nameof(entity));
        _dbSet.Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        if( entities == null || !entities.Any())
            throw new ArgumentNullException(nameof(entities));
        _dbSet.UpdateRange(entities);
    }

    public void Delete(T entity)
    {
        if( entity == null)
            throw new ArgumentNullException(nameof(entity));
        
        _dbSet.Remove(entity);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        if( entities == null || !entities.Any())
            throw new ArgumentNullException(nameof(entities));
        
        _dbSet.RemoveRange(entities);
    }
    
    #endregion
}