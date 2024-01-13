using ChurrasTrinca.Domain;

namespace ChurrasTrinca.App
{
    public class ChurrascoAppService : IChurrascoAppService
    {
        private readonly IChurrascoService _service;

        public ChurrascoAppService(IChurrascoService service)
        {
            _service = service;
        }
    }
}
