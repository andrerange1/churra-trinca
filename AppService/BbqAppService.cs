using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Interfaces;
using static Contracts.RunCreateNewBbq;
using static Contracts.RunModerateBbq;

namespace AppService
{
    public class BbqAppService : IBbqAppService
    {
        private readonly IBbqService _service;
        private readonly IMapper _mapper;

        public BbqAppService(IBbqService bbqService, IMapper mapper)
        {
            _service = bbqService;
            _mapper = mapper;
        }

        public async Task<NewBbqResponse> CreateNew(NewBbqRequest input, string userId)
        {
            var bbq = _mapper.Map<Bbq>(input);

            var response = await _service.CreateNew(bbq, userId, input.LookupId);

            return _mapper.Map<NewBbqResponse>(response);
        }

        public async Task<BbqResponse> Moderate(ModerateBbqRequest input, string bbqId)
        {
            var bbq = await _service.Modarate(bbqId, input.GonnaHappen, input.TrincaWillPay, input.LookupId);
            return _mapper.Map<BbqResponse>(bbq);
        }

        public async Task<BbqResponse?> GetAsync(string id)
        {
            var response = await _service.GetAsync(id);
            return _mapper.Map<BbqResponse>(response);
        }

        public async Task<BbbFoodListResponse> GetProposedFoodList(string bbqId)
        {
            var bbq = await GetAsync(bbqId);
            return new BbbFoodListResponse
            {
                MeatAmount = bbq.MeatAmount,
                VegetableAmount = bbq.VegetablesAmount
            };
        }
    }
}
