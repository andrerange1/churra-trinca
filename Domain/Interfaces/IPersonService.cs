using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPersonService
    {
        public Task<Person?> GetAsync(string id);
        public Task SaveAsync(Person person);
        public Task<Person> AcceptInvite(string personId, bool isVeg, string inviteId);
        public Task<Person> DeclineInvite(string personId, bool isVeg, string inviteId);
        public Task<IList<Invite>> GetProposedBbqs(string personLoggedId);
        public Task<Person> CreateNew(string name, bool isCoOwner);
        public IEventStore<Person> GetEventStore();
    }
}
