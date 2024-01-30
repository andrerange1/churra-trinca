using Contracts;
using static Contracts.RunCreateNewBbq;
using static Contracts.RunModerateBbq;

namespace AppService
{
    public interface IBbqAppService
    {
        public Task<NewBbqResponse> CreateNew(NewBbqRequest input, string userId);
        public Task<BbqResponse> Moderate(ModerateBbqRequest input, string bbqId);
        public Task<BbqResponse?> GetAsync(string id);
        public Task<BbbFoodListResponse> GetProposedFoodList(string bbqId);
    }
}
