using System.Linq.Expressions;

namespace MasterLoyaltyStore.Data.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    //Queries
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> FindAsync(
        Expression<Func<T, bool>> predicate, 
        CancellationToken cancellationToken = default);
        
    Task<T?> FirstOrDefaultAsync(
        Expression<Func<T, bool>> predicate, 
        CancellationToken cancellationToken = default);
        
    Task<bool> AnyAsync(
        Expression<Func<T, bool>> predicate, 
        CancellationToken cancellationToken = default);
        
    Task<int> CountAsync(
        Expression<Func<T, bool>>? predicate = null, 
        CancellationToken cancellationToken = default);
    
    //Pagination
    Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
        int pageNumber,
        int pageSize, Expression<Func<T, bool>> predicate,
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        CancellationToken cancellationToken = default
    );

    //Commands
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
}