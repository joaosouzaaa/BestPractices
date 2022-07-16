using BestPractices.Business.Interfaces.Pagination;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Domain.Entities;
using BestPractices.Infra.Contexts;
using BestPractices.Infra.Repository.RepositoryBase;

namespace BestPractices.Infra.Repository
{
    public class ClientRepository : BaseQueryRepository<Client>, IClientRepository
    {
        public ClientRepository(IPagingService<Client> pagingService, UserDbContext context) : base(pagingService, context)
        {
        }
    }
}
