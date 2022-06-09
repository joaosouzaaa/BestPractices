using BestPractices.Business.Interfaces.Repository.RepositoryBase;
using BestPractices.Domain.Entities;

namespace BestPractices.Business.Interfaces.Repository
{
    public interface ISupplierRepository : IBaseRepository<Supplier>
    {
        Task<Supplier> FindSupplierByCnpj(string cnpj);
        Task<Supplier> FindSupplierAndAddress(int id);
        Task<Supplier> FindSupplierAndProducts(int id);
        Task<Supplier> FindSupplierWithAllEntities(int id);
    }
}
