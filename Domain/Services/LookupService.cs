using CrossCutting;
using Domain.Entities;
using Domain.Events;
using Domain.Interfaces;
using Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class LookupService : ILookupService
    {
        private readonly ILookupsRepository _repository;
        private readonly IPersonService _personService;
        private readonly SnapshotStore _snapshots;
        public LookupService(ILookupsRepository repository, IPersonService personService, SnapshotStore snapshots)
        {
            _repository = repository;
            _personService = personService;
            _snapshots = snapshots;
        }

        public async Task<Lookups?> GetAsync(string id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Lookups> CreateNew(Lookups lookup)
        {
            var eventNewLookup = new NewLookupCreated(Guid.NewGuid(), lookup.GroupName, lookup.ModeratorIds, lookup.PeopleIds);
            lookup.Apply(eventNewLookup);

            await _repository.SaveAsync(lookup);

            return lookup;
        }

        public async Task<Lookups> AddPerson(string lookupId, string personId)
        {
            var lookup = await _repository.GetAsync(lookupId);

            var person = await _personService.GetAsync(personId);

            if (person != null) //adiciona somente quem existe. caso nao exista somente ignora.
            {
                var @event = new PersonWasAddedToLookup()
                {
                    GroupName = lookup.GroupName,
                    ModeratorIds = lookup.ModeratorIds,
                    PeopleIds = lookup.PeopleIds,
                    Id = Guid.Parse(lookup.Id),
                    NewPersonId = personId,
                    IsCoOwner = person.IsCoOwner
                };

                lookup.Apply(@event);
                await _repository.SaveAsync(lookup);
            }

            return lookup;
        }
    }
}
