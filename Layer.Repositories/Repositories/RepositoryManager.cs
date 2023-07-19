
using Layer.Repository.Repositories.Abstracts;
using Layer.Repository.UnitOfWork;

namespace Layer.Repository.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryManager(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository, 
            IUnitOfWork unitOfWork)
        {
            _productRepository=productRepository;
            _categoryRepository=categoryRepository;
            _unitOfWork=unitOfWork;
        }

        public IProductRepository ProductRepository => _productRepository;

        public ICategoryRepository CategoryRepository => _categoryRepository;

        public void Save() => _unitOfWork.Commit();

        public async Task SaveAsync() => await _unitOfWork.CommitAsync();
    }
}
