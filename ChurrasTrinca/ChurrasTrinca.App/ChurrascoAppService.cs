using AutoMapper;
using ChurrasTrinca.Contracts;
using ChurrasTrinca.Domain.Interfaces.Services;

namespace ChurrasTrinca.App
{
    public class ChurrascoAppService : IChurrascoAppService
    {
        private readonly IChurrascoService _service;
        private readonly IMapper _mapper;

        public ChurrascoAppService(IChurrascoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public ChurrascoResponse GetAsync()
        {
            var churrasco = _service.GetAsync();
            return _mapper.Map<ChurrascoResponse>(churrasco);
        }
    }
}
