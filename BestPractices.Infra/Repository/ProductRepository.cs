using BestPractices.Business.Interfaces.Pagination;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Domain.Entities;
using BestPractices.Infra.Contexts;
using BestPractices.Infra.Repository.RepositoryBase;

namespace BestPractices.Infra.Repository
{
    public class ProductRepository : BaseQueryRepository<Product>, IProductRepository
    {
        public ProductRepository(IPagingService<Product> pagingService, UserDbContext context) : base(pagingService, context)
        {
        }
    }
}
