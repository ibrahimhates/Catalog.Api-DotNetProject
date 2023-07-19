

using Layer.Repository;

namespace Layer.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogContext _context;

        public UnitOfWork(CatalogContext context)
        {
            _context=context;
        }

        public void Commit() => _context.SaveChanges();

        public async Task CommitAsync() => 
            await _context.SaveChangesAsync();
    }
}
