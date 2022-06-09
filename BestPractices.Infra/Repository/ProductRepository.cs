using BestPractices.Business.Interfaces.Repository;
using BestPractices.Domain.Entities;
using BestPractices.Infra.Contexts;
using BestPractices.Infra.Repository.RepositoryBase;

namespace BestPractices.Infra.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(UserDbContext context) : base(context)
        {
        }
    }
}
