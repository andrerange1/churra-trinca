using Domain.Entities;
using Domain.Events;
using Domain.Interfaces;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CrossCutting;


namespace Domain.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Person?> GetAsync(string id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task SaveAsync(Person person) 
        {
            await _repository.SaveAsync(person);
        }

        public async Task<Person> AcceptInvite(string personId, bool isVeg, string inviteId)
        {
            using var scope = Bootstrap.Services.CreateScope();
            var _bbqService = scope.ServiceProvider.GetService<IBbqService>();

            var person = await _repository.GetAsync(personId);

            var bbq = await _bbqService.GetAsync(inviteId);
            if (bbq.Status == BbqStatusEnum.ItsNotGonnaHappen)
                return person;

            var personIsNull = person is null;
            var bbqIsNull = bbq is null;

            if (personIsNull || bbqIsNull) { return person; }

            var statusPreviousAnswer = person.Invites.First(x => x.Id == bbq.Id)?.Status;

            if (statusPreviousAnswer != InviteStatus.Accepted) //caso a pessoa ja tenha aceitado anteriormente nao pode aceitar novamnete
            {
                bbq?.Apply(new InviteWasAccepted { IsVeg = isVeg, PersonId = person.Id }); //dispara evento que organiza a comida e adiciona pessoa na lista de confirmados
                person.Apply(new InviteWasAccepted { InviteId = bbq.Id, PersonId = person.Id });
                await _repository.SaveAsync(person);
                await _bbqService.SaveOnDb(bbq, person.Id);
            }

            return person;
        }

        public async Task<Person> DeclineInvite(string personId, bool isVeg, string inviteId)
        {
            using var scope = Bootstrap.Services.CreateScope();
            var _bbqService = scope.ServiceProvider.GetService<IBbqService>();

            var person = await _repository.GetAsync(personId);

            var bbq = await _bbqService.GetAsync(inviteId);

            if (bbq.Status == BbqStatusEnum.ItsNotGonnaHappen)
                return person;

            var personIsNull = person is null;
            var bbqIsNull = bbq is null;

            if (personIsNull || bbqIsNull) { return person; }

            var status = person.Invites.First(x => x.Id == bbq.Id)?.Status;

            if (status == InviteStatus.Accepted)
            {
                bbq.Apply(new InviteWasDeclined(bbq.Id, person.Id, isVeg)); //altera a lista de convidos e a lista de compras
                await _bbqService.SaveOnDb(bbq, person.Id);
            }

            person.Apply(new InviteWasDeclined(bbq.Id, person.Id, isVeg));
            await _repository.SaveAsync(person);

            return person;
        }

        public async Task<IList<Invite>> GetProposedBbqs(string personId)
        {
            var person = await GetAsync(personId);
            return person.Invites.Where(i => i.Date > DateTime.Now && i.Status != InviteStatus.Declined).ToList();
        }


        public async Task<Person> CreateNew(string name, bool isCoOwner)
        {
            var person = new Person();
            person.Apply(new PersonHasBeenCreated(Guid.NewGuid().ToString(), name, isCoOwner));
            await SaveAsync(person);

            return person;
        }

        public IEventStore<Person> GetEventStore()
        {
            return _repository.GetEventStore();
        }
    }
}
