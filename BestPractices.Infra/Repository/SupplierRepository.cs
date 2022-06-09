using BestPractices.Business.Interfaces.Repository;
using BestPractices.Domain.Entities;
using BestPractices.Infra.Contexts;
using BestPractices.Infra.Repository.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace BestPractices.Infra.Repository
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(UserDbContext context) : base(context)
        {
        }

        public async Task<Supplier> FindSupplierByCnpj(string cnpj) => 
            await DbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.CNPJ == cnpj);

        public async Task<Supplier> FindSupplierAndAddress(int id) => 
            await DbSet.AsNoTracking()
            .Include(s => s.CompanyAddress).AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);

        public async Task<Supplier> FindSupplierAndProducts(int id) =>
            await DbSet.AsNoTracking()
            .Include(s => s.Products).AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);

        public async Task<Supplier> FindSupplierWithAllEntities(int id) =>
            await DbSet.AsNoTracking()
            .Include(s => s.CompanyAddress).AsNoTracking()
            .Include(s => s.Products).AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}
