using Layer.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Layer.Repository.Repositories.GenericBase
{
    public class GenericRepositoryBase<T> : IGenericRepositoryBase<T>
        where T : class
    {
        private readonly CatalogContext _context;

        public GenericRepositoryBase(CatalogContext context)
        {
            _context=context;
        }

        public IQueryable<T> GetAll(bool trackChanges) =>
            trackChanges?
            _context.Set<T>().AsTracking():
            _context.Set<T>().AsNoTracking();

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            trackChanges ?
            _context.Set<T>().Where(expression).AsTracking() :
            _context.Set<T>().Where(expression).AsNoTracking();

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, bool trackChanges) =>
            trackChanges ?
            await _context.Set<T>().AsTracking().AnyAsync(expression) :
            await _context.Set<T>().AsNoTracking().AnyAsync(expression);

        public async Task CreateAsync(T entity) => await _context.Set<T>().AddAsync(entity);

        public async Task CreateRangeAsync(IEnumerable<T> entity) => 
            await _context.Set<T>().AddRangeAsync(entity);

        public void Delete(T entity) => _context.Remove(entity);

        public void Update(T entity) => _context.Update(entity);

    }
}
