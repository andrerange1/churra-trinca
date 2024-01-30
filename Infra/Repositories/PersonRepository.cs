using Domain.Entities;
using Domain.Repositories;

namespace Repositories
{
    internal class PersonRepository : StreamRepository<Person>, IPersonRepository
    {
        private readonly IEventStore<Person> _eventStore;

        public PersonRepository(IEventStore<Person> eventStore) : base(eventStore) {
            _eventStore = eventStore;
        }

        public IEventStore<Person> GetEventStore()
        {
            return _eventStore;
        }
    }
}
