using BestPractices.Business.Interfaces.Repository;
using BestPractices.Domain.Entities;
using BestPractices.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BestPractices.Infra.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly UserDbContext _dbContext;

        public ClientRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private async Task Save() => await _dbContext.SaveChangesAsync();

        public async Task Save(Client client)
        {
            this._dbContext.Clients.Add(client);

            this._dbContext.Entry(client).State = EntityState.Added;

            await Save();
        }

        public async Task Update(Client client)
        {
            this._dbContext.Entry(client).State = EntityState.Modified;

            await Save();
        }

        public async Task Delete(int id)
        {
            Client client = await GetClientById(id);

            this._dbContext.Entry(client).State = EntityState.Deleted;

            await Save();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await this._dbContext.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Client>> GetAllClients()
        {
            return await this._dbContext.Clients.ToListAsync();
        }

        public bool ClientExist(int id) => this._dbContext.Clients.Any(c => c.Id == id);

        public void Dispose() => this._dbContext.Dispose();
    }
}
