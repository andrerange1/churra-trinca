using Domain.Entities;
using Domain.Events;
using Domain.Interfaces;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class BbqService : IBbqService
    {
        private readonly IBbqRepository _repository;
        private readonly ILookupService _lookupService;
        private readonly IPersonService _personService;
        public BbqService(IBbqRepository repository, ILookupService lookupService, IPersonService personService)
        {
            _repository = repository;
            _lookupService = lookupService;
            _personService = personService;
        }

        public IEventStore<Bbq> GetEventStore()
        {
            return _repository.GetEventStore();
        }

        public async Task SaveOnDb(Bbq bbq, string userId)
        {
            await _repository.SaveOnDb(bbq, userId);
        }

        private async Task InvitePerson(Bbq bbq, Person? person)
        {
            var @event = new PersonHasBeenInvitedToBbq(bbq.Id, bbq.Date, bbq.Reason);
            person.Apply(@event);
            await _personService.SaveAsync(person);
        }

        public async Task<Bbq> CreateNew(Bbq bbq, string userId, string lookupId)
        {   
            var eventNewBbq = new ThereIsSomeoneElseInTheMood(Guid.NewGuid(), bbq.Date, bbq.Reason, bbq.IsTrincasPaying);
            bbq.Apply(eventNewBbq);        

            var lookups = await _lookupService.GetAsync(lookupId);

            foreach (var personId in lookups.ModeratorIds)
            {
                var person = await _personService.GetAsync(personId);
                await InvitePerson(bbq, person);
                bbq.PeopleId.Append(personId);
            }
            await SaveOnDb(bbq, userId);
            return bbq;
        }       

        public async Task<Bbq> Modarate(string id, bool gonnaHappen, bool trincaWillPay, string lookupId)
        {
            var bbq = await _repository.GetAsync(id);

            bbq.Apply(new BbqStatusUpdated(gonnaHappen, trincaWillPay));

            var lookups = await _lookupService.GetAsync(lookupId);

            var peopleToInvite = gonnaHappen ? lookups.PeopleIds.Except(lookups.ModeratorIds).ToList() : new List<string>();

            foreach (var personId in peopleToInvite)
            {
                var person = await _personService.GetAsync(personId);
                var alreadyInvited = person.Invites.FirstOrDefault(x => x.Id == id);
                if(alreadyInvited is null)
                {
                    await InvitePerson(bbq, person);
                } else
                {
                    alreadyInvited.Status = InviteStatus.Pending;
                    await _personService.SaveAsync(person);
                }
            }

            if (!gonnaHappen && lookups != null)
            {
                foreach (var personId in lookups.PeopleIds)
                {
                    var person = await _personService.GetAsync(personId);
                    var alreadyInvited = person.Invites.FirstOrDefault(x => x.Id == id);

                    if (alreadyInvited != null)
                    {
                        var @event = new InviteWasDeclined(bbq.Id, person.Id, true);
                        person.Apply(@event);
                        await _personService.SaveAsync(person);
                    } 
                }
            }

            await _repository.SaveAsync(bbq);

            return bbq;
        }

        public async Task<Bbq?> GetAsync(string id)
        {
            return await _repository.GetAsync(id);
        }
    }
}
