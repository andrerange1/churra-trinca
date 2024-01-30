using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBbqService
    {
        public Task<Bbq> Modarate(string id, bool gonnaHappen, bool trincaWillPay, string lookupId);
        public IEventStore<Bbq> GetEventStore();
        public Task<Bbq> CreateNew(Bbq bbq, string userId, string lookupId);
        public Task SaveOnDb(Bbq bbq, string userId);
        public Task<Bbq?> GetAsync(string id);
    }
}