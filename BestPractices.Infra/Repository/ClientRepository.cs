﻿using BestPractices.Business.Interfaces.Repository;
using BestPractices.Domain.Entities;
using BestPractices.Infra.Contexts;
using BestPractices.Infra.Repository.RepositoryBase;

namespace BestPractices.Infra.Repository
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(UserDbContext context) : base(context)
        {
        }
    }
}
