using Contracts;
using static Contracts.RunAcceptInvite;

namespace AppService
{
    public interface IPersonAppService
    {
        public Task<PersonResponse?> GetAsync(string id);
        public Task<PersonResponse> AcceptInvite(string personId, InviteAnswer answer, string inviteId);
        public Task<PersonResponse> DeclineInvite(string personId, InviteAnswer answer, string inviteId);
        public Task<IList<InviteResponse>> GetProposedBbqs(string personLoggedId);
        public Task<NewPersonResponse> CreateNew(NewPersonRequest input);
    }
}
