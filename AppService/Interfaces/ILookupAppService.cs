using Contracts;

namespace AppService
{
    public interface ILookupAppService
    {
        public Task<NewLookupResponse> CreateNew(NewLookupRequest request, string userId);
        public Task<LookupResponse?> GetAsync(string id);
        public Task<LookupResponse> AddPerson(AddPersonToALookupRequest request, string lookupId);
    }
}
