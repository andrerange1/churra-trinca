using Domain.Entities;
using Domain.Repositories;
using Eveneum;

namespace Repositories
{
    internal class LookupsRepository : StreamRepository<Lookups>, ILookupsRepository
    {
        private readonly IEventStore<Lookups> _eventStore;

        public LookupsRepository(IEventStore<Lookups> eventStore) : base(eventStore)
        {
            _eventStore = eventStore;
        }
        public IEventStore<Lookups> GetEventStore()
        {
            return _eventStore;
        }

        public async Task SaveOnDb(Lookups lookup)
        {
            await _eventStore.WriteToStream(lookup.Id, lookup.Changes.Select(evento => new EventData(lookup.Id, evento, new { CreatedBy = lookup.ModeratorIds.First() }, lookup.Version, DateTime.Now.ToString())).ToArray(), expectedVersion: lookup.Version == 0 ? null : lookup.Version);
        }
    }
}
