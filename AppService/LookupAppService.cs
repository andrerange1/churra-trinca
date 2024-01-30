using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Interfaces;

namespace AppService
{
    public class LookupAppService : ILookupAppService
    {
        private readonly ILookupService _service;
        private readonly IMapper _mapper;

        public LookupAppService(ILookupService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<LookupResponse> AddPerson(AddPersonToALookupRequest request, string lookupId)
        {
            var response = await _service.AddPerson(lookupId, request.PersonId);

            return _mapper.Map<LookupResponse>(response);
        }

        public async Task<NewLookupResponse> CreateNew(NewLookupRequest request, string userId)
        {
            var lookup = _mapper.Map<Lookups>(request);

            lookup.ModeratorIds.Add(userId);
            lookup.PeopleIds.Add(userId);

            var response = await _service.CreateNew(lookup);

            return _mapper.Map<NewLookupResponse>(response);
        }

        public async Task<LookupResponse?> GetAsync(string id)
        {
            var response = await _service.GetAsync(id);
            return _mapper.Map<LookupResponse>(response);
        }
    }
}
