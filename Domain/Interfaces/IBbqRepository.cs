using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBbqRepository : IStreamRepository<Bbq>
    {
        public IEventStore<Bbq> GetEventStore();
        public Task SaveOnDb(Bbq bbq, string userId);

    }
}