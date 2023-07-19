using Layer.Repository.Repositories.Abstracts;

namespace Layer.Repository.Repositories
{
    public interface IRepositoryManager
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        Task SaveAsync();
        void Save();
    }
}
