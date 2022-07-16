using BestPractices.Business.Interfaces.Pagination;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Domain.Entities;
using BestPractices.Infra.Contexts;
using BestPractices.Infra.Repository.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace BestPractices.Infra.Repository
{
    public class SupplierRepository : BaseQueryRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(IPagingService<Supplier> pagingService, UserDbContext context) : base(pagingService, context)
        {
        }
    }
}
