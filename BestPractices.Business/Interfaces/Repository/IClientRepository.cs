using BestPractices.Domain.Entities;

namespace BestPractices.Business.Interfaces.Repository
{
    public interface IClientRepository
    {
        Task Save(Client client);
        Task Update(Client client);
        Task Delete(int id);
        Task<Client> GetClientById(int id);
        Task<List<Client>> GetAllClients();
        bool ClientExist(int id);
    }
}
