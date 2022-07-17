using BestPractices.Business.Interfaces.Repository.RepositoryBase;
using BestPractices.Domain.Entities;

namespace BestPractices.Business.Interfaces.Repository
{
    public interface ISupplierRepository : IBaseQueryRepository<Supplier>, IGenericFind
    {
    }
}
