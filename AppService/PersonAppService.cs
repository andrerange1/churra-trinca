using AutoMapper;
using Contracts;
using Domain.Interfaces;
using static Contracts.RunAcceptInvite;

namespace AppService
{
    public class PersonAppService : IPersonAppService
    {
        private readonly IPersonService _service;
        private readonly IMapper _mapper;

        public PersonAppService(IPersonService personService, IMapper mapper )
        {
            _service = personService;
            _mapper = mapper;
        }
         
        public async Task<PersonResponse?> GetAsync(string id)
        {
            var response = await _service.GetAsync(id);
            return _mapper.Map<PersonResponse>(response);
        }

        public async Task<PersonResponse> AcceptInvite(string personId, InviteAnswer answer, string inviteId)
        {
            var response = await _service.AcceptInvite(personId, answer.IsVeg, inviteId);
            return _mapper.Map<PersonResponse>(response);
        }

        public async Task<PersonResponse> DeclineInvite(string personId, InviteAnswer answer, string inviteId)
        {
            var response = await _service.DeclineInvite(personId, answer.IsVeg, inviteId);
            return _mapper.Map<PersonResponse>(response);
        }

        public async Task<IList<InviteResponse>> GetProposedBbqs(string personLoggedId)
        {
            var response = await _service.GetProposedBbqs(personLoggedId);
            return _mapper.Map<IList<InviteResponse>>(response);
        }

        public async Task<NewPersonResponse> CreateNew(NewPersonRequest input)
        {
            var response = await _service.CreateNew(input.Name, input.IsCoOwner);
            return _mapper.Map<NewPersonResponse>(response);
        }
    }
}
