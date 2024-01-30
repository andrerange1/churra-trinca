using Domain.Entities;
using Domain.Repositories;
using Eveneum;

namespace Repositories
{
    internal class BbqRepository : StreamRepository<Bbq>, IBbqRepository
    {
        private readonly IEventStore<Bbq> _eventStore;

        public BbqRepository(IEventStore<Bbq> eventStore) : base(eventStore) {
            _eventStore = eventStore;
        }

        public IEventStore<Bbq> GetEventStore()
        {
            return _eventStore;
        }

        public async Task SaveOnDb(Bbq bbq, string userId)
        {
            await _eventStore.WriteToStream(bbq.Id, bbq.Changes.Select(evento => new EventData(bbq.Id, evento, new { CreatedBy = userId }, bbq.Version, DateTime.Now.ToString())).ToArray(), expectedVersion: bbq.Version == 0 ? null : bbq.Version);
        }
    }
}
