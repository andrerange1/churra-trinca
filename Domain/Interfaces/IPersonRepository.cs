using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPersonRepository : IStreamRepository<Person>
    {
        public IEventStore<Person> GetEventStore();
    }
}